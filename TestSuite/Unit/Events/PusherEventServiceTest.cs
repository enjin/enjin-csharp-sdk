/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.Threading;
using Enjin.SDK.Events;
using Enjin.SDK.Models;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;
using static TestSuite.Utils.PlatformUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherEventServiceTest
    {
        [Test]
        public void Connected_ServiceNotStarted_EventTriggersAfterStart()
        {
            // Arrange
            bool flag = false;
            var eventService = CreateEventService();
            eventService.Connected += (sender, args) => { flag = true; };

            // Act
            eventService.Start().Wait();

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(flag);
        }

        [Test]
        public void Disconnected_ServiceStarted_EventTriggersAfterShutdown()
        {
            // Arrange
            bool flag = false;
            var eventService = CreateEventService();
            eventService.Start().Wait();
            eventService.Disconnected += (sender, args) => { flag = true; };

            // Act
            eventService.Shutdown().Wait();

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(flag);
        }

        [Test]
        public void RegisterListener_DoesContainListenerRegistration()
        {
            // Arrange
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListener(listener);

            // Assert
            Assert.IsTrue(eventService.RegisteredListeners.Contains(registration));
        }

        [Test]
        public void UnregisterListener_DoesNotContainListenerRegistration()
        {
            // Arrange
            var listener = new EventListener();
            var eventService = CreateEventService();
            var registration = eventService.RegisterListener(listener);

            // Act
            eventService.UnregisterListener(listener);

            // Assert
            Assert.IsFalse(eventService.RegisteredListeners.Contains(registration));
        }

        [Test]
        public void RegisterListener_RegistrationHasListener()
        {
            // Arrange
            var expected = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListener(expected);
            var actual = registration.Listener;

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void RegisterListener_RegisteringSameListenerReturnsSameRegistration()
        {
            // Arrange
            var listener = new EventListener();
            var eventService = CreateEventService();
            var expected = eventService.RegisterListener(listener);

            // Act
            var actual = eventService.RegisterListener(listener);

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void RegisterListener_RegistrationUsesAllowAllMatcher()
        {
            // Arrange
            var expected = EventListenerRegistration.ALLOW_ALL_MATCHER;
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListener(listener);
            var actual = registration.Matcher;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RegisterListenerWithMatcher_RegistrationHasMatcher()
        {
            // Arrange
            var expected = new Func<EventType, bool>(type => true);
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListenerWithMatcher(listener, expected);
            var actual = registration.Matcher;

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        [TestCase(EventType.PLAYER_LINKED)]
        [TestCase(EventType.ASSET_MINTED, EventType.ASSET_TRANSFERRED, EventType.TRANSACTION_EXECUTED)]
        [TestCase(EventType.PROJECT_CREATED, EventType.PROJECT_DELETED, EventType.PROJECT_UPDATED)]
        public void RegisterListenerIncludingTypes_MatcherIncludesEventTypes(params EventType[] includedTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListenerIncludingTypes(listener, includedTypes);
            var matcher = registration.Matcher;

            // Assert
            foreach (EventType type in types)
            {
                var expected = includedTypes.Contains(type);
                var actual = matcher(type);
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        [TestCase(EventType.PLAYER_LINKED)]
        [TestCase(EventType.ASSET_MINTED, EventType.ASSET_TRANSFERRED, EventType.TRANSACTION_EXECUTED)]
        [TestCase(EventType.PROJECT_CREATED, EventType.PROJECT_DELETED, EventType.PROJECT_UPDATED)]
        public void RegisterListenerExcludingTypes_MatcherExcludesEventTypes(params EventType[] excludedTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListenerExcludingTypes(listener, excludedTypes);
            var matcher = registration.Matcher;

            // Assert
            foreach (EventType type in types)
            {
                var expected = excludedTypes.Contains(type);
                var actual = matcher(type);
                Assert.AreNotEqual(expected, actual);
            }
        }

        [Test]
        public void SubscribeToProject_SubscribedToChannel()
        {
            // Arrange
            const string project = "xyz";
            var eventService = CreateEventService();
            eventService.Start().Wait();

            Expect(eventService.IsSubscribedToProject(project)).To.Be.False();

            // Act
            eventService.SubscribeToProject(project);

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToProject(project));
        }

        [Test]
        public void SubscribeToPlayer_SubscribedToChannel()
        {
            // Arrange
            const string project = "xyz";
            const string player = "player1";
            var eventService = CreateEventService();
            eventService.Start().Wait();

            Expect(eventService.IsSubscribedToPlayer(project, player)).To.Be.False();

            // Act
            eventService.SubscribeToPlayer(project, player);

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToPlayer(project, player));
        }

        [Test]
        public void SubscribeToAsset_SubscribedToChannel()
        {
            // Arrange
            const string asset = "0000000000000000";
            var eventService = CreateEventService();
            eventService.Start().Wait();

            Expect(eventService.IsSubscribedToAsset(asset)).To.Be.False();

            // Act
            eventService.SubscribeToAsset(asset);

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToAsset(asset));
        }

        [Test]
        public void SubscribeToWallet_SubscribedToChannel()
        {
            // Arrange
            const string wallet = "0x0";
            var eventService = CreateEventService();
            eventService.Start().Wait();

            Expect(eventService.IsSubscribedToWallet(wallet)).To.Be.False();

            // Act
            eventService.SubscribeToWallet(wallet);

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToWallet(wallet));
        }

        [Test]
        public void UnsubscribeToProject_UnsubscribedToChannel()
        {
            // Arrange
            const string project = "xyz";
            var eventService = CreateEventService();
            eventService.Start().Wait();
            eventService.SubscribeToProject(project);
            Thread.Sleep(500);

            Expect(eventService.IsSubscribedToProject(project)).To.Be.True();

            // Act
            eventService.UnsubscribeToProject(project);

            Thread.Sleep(500);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToProject(project));
        }

        [Test]
        public void UnsubscribeToPlayer_UnsubscribedToChannel()
        {
            // Arrange
            const string project = "xyz";
            const string player = "player1";
            var eventService = CreateEventService();
            eventService.Start().Wait();
            eventService.SubscribeToPlayer(project, player);
            Thread.Sleep(500);

            Expect(eventService.IsSubscribedToPlayer(project, player)).To.Be.True();

            // Act
            eventService.UnsubscribeToPlayer(project, player);

            Thread.Sleep(500);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToPlayer(project, player));
        }

        [Test]
        public void UnsubscribeToAsset_UnsubscribedToChannel()
        {
            // Arrange
            const string asset = "0000000000000000";
            var eventService = CreateEventService();
            eventService.Start().Wait();
            eventService.SubscribeToAsset(asset);
            Thread.Sleep(500);

            Expect(eventService.IsSubscribedToAsset(asset)).To.Be.True();

            // Act
            eventService.UnsubscribeToAsset(asset);

            Thread.Sleep(500);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToAsset(asset));
        }

        [Test]
        public void UnsubscribeToWallet_UnsubscribedToChannel()
        {
            // Arrange
            const string wallet = "0x0";
            var eventService = CreateEventService();
            eventService.Start().Wait();
            eventService.SubscribeToWallet(wallet);
            Thread.Sleep(500);

            Expect(eventService.IsSubscribedToWallet(wallet)).To.Be.True();

            // Act
            eventService.UnsubscribeToWallet(wallet);

            Thread.Sleep(500);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToWallet(wallet));
        }

        [Test]
        public void Start_PreviouslyActiveServiceResubscribesToChannels()
        {
            // Arrange
            const string project = "xyz";
            var eventService = CreateEventService();
            eventService.Start().Wait();              // Service is started for the first time and subscribes to the
            eventService.SubscribeToProject(project); // channel
            Thread.Sleep(500);         //
            eventService.Shutdown().Wait(); // Shutdown the service to be restarted on 'Act'

            Expect(eventService.IsSubscribedToProject(project)).To.Be.True();

            // Act
            eventService.Start().Wait();

            Thread.Sleep(500);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToProject(project));
        }

        private static PusherEventService CreateEventService() => new PusherEventService(FakePlatform);

        private class EventListener : IEventListener
        {
            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }
    }
}
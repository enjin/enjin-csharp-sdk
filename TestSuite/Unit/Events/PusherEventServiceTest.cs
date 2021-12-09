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
using Enjin.SDK.Events;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.PlatformUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherEventServiceTest
    {
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

        private static PusherEventService CreateEventService() => new PusherEventService(FakePlatform);

        private class EventListener : IEventListener
        {
            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }
    }
}
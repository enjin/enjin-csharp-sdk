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
using static Enjin.SDK.Events.EventListenerRegistration;

namespace TestSuite
{
    [TestFixture]
    public class EventListenerRegistrationTest
    {
        [Test]
        public void AllowAllMatcher_AllowsAllEventTypes()
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var matcher = ALLOW_ALL_MATCHER;
            
            // Assert
            foreach (EventType type in types)
                Assert.IsTrue(matcher(type));
        }
        
        [Test]
        public void Configure_AllowFilter_RegistrationMatcherUsesFilter()
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new AllowedFilteredEventListener();
            var allowedEvents = AllowedFilteredEventListener.AllowedEvents;

            // Act
            var registration = Configure(listener).Create();
            var matcher = registration.Matcher;

            // Assert
            foreach (EventType type in types)
            {
                var expected = allowedEvents.Contains(type);
                var actual = matcher(type);
                Assert.AreEqual(expected, actual);
            }
        }
        
        [Test]
        public void Configure_IgnoreFilter_RegistrationMatcherUsesFilter()
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new IgnoredFilteredEventListener();
            var allowedEvents = IgnoredFilteredEventListener.IgnoredEvents;

            // Act
            var registration = Configure(listener).Create();
            var matcher = registration.Matcher;

            // Assert
            foreach (EventType type in types)
            {
                var expected = allowedEvents.Contains(type);
                var actual = matcher(type);
                Assert.AreNotEqual(expected, actual);
            }
        }

        [Test]
        public void Create_RegistrationHasListener()
        {
            // Arrange
            var expected = new EventListener();
            var configuration = Configure(expected);
            
            // Act
            var registration = configuration.Create();
            var actual = registration.Listener;

            // Assert
            Assert.AreSame(expected, actual);
        }
        
        [Test]
        public void WithMatcher_RegistrationHasMatcher()
        {
            // Arrange
            var expected = new Func<EventType, bool>(type => true);
            var configuration = CreateConfiguration();
            
            // Act
            var registration = configuration.WithMatcher(expected)
                                            .Create();
            var actual = registration.Matcher;

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        [TestCase(EventType.PLAYER_LINKED)]
        [TestCase(EventType.ASSET_MINTED, EventType.ASSET_TRANSFERRED, EventType.TRANSACTION_EXECUTED)]
        [TestCase(EventType.PROJECT_CREATED, EventType.PROJECT_DELETED, EventType.PROJECT_UPDATED)]
        public void WithAllowedEvents_RegistrationMatcherIncludesEvents(params EventType[] includedTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var configuration = CreateConfiguration();

            // Act
            var registration = configuration.WithAllowedEvents(includedTypes)
                                            .Create();
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
        public void WithIgnoredEvents_RegistrationMatcherIgnoresEvents(params EventType[] ignoredTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var configuration = CreateConfiguration();

            // Act
            var registration = configuration.WithIgnoredEvents(ignoredTypes)
                                            .Create();
            var matcher = registration.Matcher;

            // Assert
            foreach (EventType type in types)
            {
                var expected = ignoredTypes.Contains(type);
                var actual = matcher(type);
                Assert.AreNotEqual(expected, actual);
            }
        }

        private static RegistrationListenerConfiguration CreateConfiguration()
        {
            return Configure(new EventListener());
        }

        private class EventListener : IEventListener
        {
            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }

        [EventFilter(true, EventType.PLAYER_LINKED, EventType.PLAYER_UNLINKED)]
        private class AllowedFilteredEventListener : IEventListener
        {
            public static EventType[] AllowedEvents { get; } = {EventType.PLAYER_LINKED, EventType.PLAYER_UNLINKED};

            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }
        
        [EventFilter(false, EventType.PLAYER_LINKED, EventType.PLAYER_UNLINKED)]
        private class IgnoredFilteredEventListener : IEventListener
        {
            public static EventType[] IgnoredEvents { get; } = {EventType.PLAYER_LINKED, EventType.PLAYER_UNLINKED};

            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }
    }
}
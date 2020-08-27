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
        public void Configure_RegistrationMatcherUsesFilterAttribute()
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new FilteredEventListener();
            var allowedEvents = FilteredEventListener.AllowedEvents;

            // Act
            var registration = Configure(listener).Create();

            // Assert
            foreach (EventType type in types)
            {
                if (allowedEvents.Contains(type))
                    Assert.IsTrue(registration.Matcher(type));
                else
                    Assert.IsFalse(registration.Matcher(type));
            }
        }

        [Test]
        public void Create_RegistrationHasListener()
        {
            // Arrange
            var listener = new EventListener();
            var configuration = Configure(listener);
            
            // Act
            var registration = configuration.Create();

            // Assert
            Assert.AreSame(listener, registration.Listener);
        }
        
        [Test]
        public void WithMatcher_RegistrationHasMatcher()
        {
            // Arrange
            var matcher = new Func<EventType, bool>(type => true);
            var configuration = CreateConfiguration();
            
            // Act
            var registration = configuration.WithMatcher(matcher)
                                            .Create();

            // Assert
            Assert.AreSame(matcher, registration.Matcher);
        }

        [Test]
        [TestCase(EventType.PLAYER_LINKED)]
        [TestCase(EventType.TOKEN_MINTED, EventType.TOKEN_TRANSFERRED, EventType.TRANSACTION_EXECUTED)]
        [TestCase(EventType.APP_CREATED, EventType.APP_DELETED, EventType.APP_UPDATED)]
        public void WithAllowedEvents_RegistrationMatcherIncludesEvents(params EventType[] includedTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var configuration = CreateConfiguration();

            // Act
            var registration = configuration.WithAllowedEvents(includedTypes)
                                            .Create();

            // Assert
            foreach (EventType type in types)
            {
                if (includedTypes.Contains(type))
                    Assert.IsTrue(registration.Matcher(type));
                else
                    Assert.IsFalse(registration.Matcher(type));
            }
        }
        
        [Test]
        [TestCase(EventType.PLAYER_LINKED)]
        [TestCase(EventType.TOKEN_MINTED, EventType.TOKEN_TRANSFERRED, EventType.TRANSACTION_EXECUTED)]
        [TestCase(EventType.APP_CREATED, EventType.APP_DELETED, EventType.APP_UPDATED)]
        public void WithIgnoredEvents_RegistrationMatcherIgnoresEvents(params EventType[] ignoredTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var configuration = CreateConfiguration();

            // Act
            var registration = configuration.WithIgnoredEvents(ignoredTypes)
                                            .Create();

            // Assert
            foreach (EventType type in types)
            {
                if (ignoredTypes.Contains(type))
                    Assert.IsFalse(registration.Matcher(type));
                else
                    Assert.IsTrue(registration.Matcher(type));
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
        private class FilteredEventListener : IEventListener
        {
            public static EventType[] AllowedEvents { get; } = {EventType.PLAYER_LINKED, EventType.PLAYER_UNLINKED};

            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }
    }
}
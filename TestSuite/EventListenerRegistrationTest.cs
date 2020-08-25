using System;
using System.Linq;
using Enjin.SDK.Events;
using Enjin.SDK.Models;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class EventListenerRegistrationTest
    {
        [Test]
        public void AllowAllMatcher_AllowsAllEventTypes()
        {
            // Arrange
            var matcher = EventListenerRegistration.ALLOW_ALL_MATCHER;
            
            // Assert
            foreach (EventType type in Enum.GetValues(typeof(EventType)))
                Assert.IsTrue(matcher(type));
        }
        
        [Test]
        public void Configure_ConfigurationAppliesEventFilterAttribute()
        {
            // Arrange
            var listener = new FilteredEventListener();
            var allowedEvents = FilteredEventListener.AllowedEvents;

            // Act
            var registration = EventListenerRegistration.Configure(listener).Create();

            // Assert
            foreach (EventType type in Enum.GetValues(typeof(EventType)))
            {
                if (allowedEvents.Contains(type))
                    Assert.IsTrue(registration.Matcher(type));
                else
                    Assert.IsFalse(registration.Matcher(type));
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
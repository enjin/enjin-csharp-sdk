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
            const int project = 1234;
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToProject(project);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToProject(project));
        }

        [Test]
        public void SubscribeToPlayer_SubscribedToChannel()
        {
            // Arrange
            const int project = 1234;
            const string player = "player1";
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToPlayer(project, player);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToPlayer(project, player));
        }

        [Test]
        public void SubscribeToAsset_SubscribedToChannel()
        {
            // Arrange
            const string asset = "0000000000000000";
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToAsset(asset);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToAsset(asset));
        }

        [Test]
        public void SubscribeToWallet_SubscribedToChannel()
        {
            // Arrange
            const string wallet = "0x0";
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToWallet(wallet);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToWallet(wallet));
        }

        [Test]
        public void UnsubscribeToProject_UnsubscribedToChannel()
        {
            // Arrange
            const int project = 1234;
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToProject(project);

            // Act
            eventService.UnsubscribeToProject(project);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToProject(project));
        }

        [Test]
        public void UnsubscribeToPlayer_UnsubscribedToChannel()
        {
            // Arrange
            const int project = 1234;
            const string player = "player1";
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToPlayer(project, player);

            // Act
            eventService.UnsubscribeToPlayer(project, player);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToPlayer(project, player));
        }

        [Test]
        public void UnsubscribeToAsset_UnsubscribedToChannel()
        {
            // Arrange
            const string asset = "0000000000000000";
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToAsset(asset);

            // Act
            eventService.UnsubscribeToAsset(asset);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToAsset(asset));
        }

        [Test]
        public void UnsubscribeToWallet_UnsubscribedToChannel()
        {
            // Arrange
            const string wallet = "0x0";
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToWallet(wallet);

            // Act
            eventService.UnsubscribeToWallet(wallet);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToWallet(wallet));
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
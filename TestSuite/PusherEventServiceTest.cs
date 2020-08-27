﻿using System;
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
            var expectedListener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListener(expectedListener);

            // Assert
            Assert.AreSame(expectedListener, registration.Listener);
        }

        [Test]
        public void RegisterListener_RegistrationUsesAllowAllMatcher()
        {
            // Arrange
            var expectedMatcher = EventListenerRegistration.ALLOW_ALL_MATCHER;
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListener(listener);

            // Assert
            Assert.AreEqual(expectedMatcher, registration.Matcher);
        }

        [Test]
        public void RegisterListenerWithMatcher_RegistrationHasMatcher()
        {
            // Arrange
            var expectedMatcher = new Func<EventType, bool>(type => true);
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListenerWithMatcher(listener, expectedMatcher);

            // Assert
            Assert.AreSame(expectedMatcher, registration.Matcher);
        }

        [Test]
        [TestCase(EventType.PLAYER_LINKED)]
        [TestCase(EventType.TOKEN_MINTED, EventType.TOKEN_TRANSFERRED, EventType.TRANSACTION_EXECUTED)]
        [TestCase(EventType.APP_CREATED, EventType.APP_DELETED, EventType.APP_UPDATED)]
        public void RegisterListenerIncludingTypes_MatcherIncludesEventTypes(params EventType[] includedTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListenerIncludingTypes(listener, includedTypes);

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
        public void RegisterListenerExcludingTypes_MatcherExcludesEventTypes(params EventType[] excludedTypes)
        {
            // Arrange
            var types = Enum.GetValues(typeof(EventType));
            var listener = new EventListener();
            var eventService = CreateEventService();

            // Act
            var registration = eventService.RegisterListenerExcludingTypes(listener, excludedTypes);

            // Assert
            foreach (EventType type in types)
            {
                if (excludedTypes.Contains(type))
                    Assert.IsFalse(registration.Matcher(type));
                else
                    Assert.IsTrue(registration.Matcher(type));
            }
        }

        [Test]
        public void SubscribeToApp_SubscribedToChannel()
        {
            // Arrange
            const int app = 1234;
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToApp(app);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToApp(app));
        }

        [Test]
        public void SubscribeToPlayer_SubscribedToChannel()
        {
            // Arrange
            const int app = 1234;
            const string player = "player1";
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToPlayer(app, player);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToPlayer(app, player));
        }

        [Test]
        public void SubscribeToToken_SubscribedToChannel()
        {
            // Arrange
            const string token = "0000000000000000";
            var eventService = CreateEventService();
            eventService.Start();

            // Act
            eventService.SubscribeToToken(token);

            // Assert
            Assert.IsTrue(eventService.IsSubscribedToToken(token));
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
        public void UnsubscribeToApp_UnsubscribedToChannel()
        {
            // Arrange
            const int app = 1234;
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToApp(app);

            // Act
            eventService.UnsubscribeToApp(app);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToApp(app));
        }

        [Test]
        public void UnsubscribeToPlayer_UnsubscribedToChannel()
        {
            // Arrange
            const int app = 1234;
            const string player = "player1";
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToPlayer(app, player);

            // Act
            eventService.UnsubscribeToPlayer(app, player);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToPlayer(app, player));
        }

        [Test]
        public void UnsubscribeToToken_UnsubscribedToChannel()
        {
            // Arrange
            const string token = "0000000000000000";
            var eventService = CreateEventService();
            eventService.Start();
            eventService.SubscribeToToken(token);

            // Act
            eventService.UnsubscribeToToken(token);

            // Assert
            Assert.IsFalse(eventService.IsSubscribedToToken(token));
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

        private static PusherEventService CreateEventService() => new PusherEventService(CreatePlatform(Kovan));

        private class EventListener : IEventListener
        {
            public void NotificationReceived(NotificationEvent notificationEvent)
            {
            }
        }
    }
}
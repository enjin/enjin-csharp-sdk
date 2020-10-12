using System;
using Enjin.SDK.Models;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class NotificationEventTest
    {
        private const EventType DefaultEventType = EventType.UNKNOWN;
        private const string DefaultChannel = "xyz";
        private const string DefaultMessage = @"{'name': 'value'}";

        [Test]
        public void Constructor_NonNullArguments_DoesNotThrowException()
        {
            // Arrange
            void TestDelegate()
            {
                new NotificationEvent(DefaultEventType, DefaultChannel, DefaultMessage);
            }

            // Assert
            Assert.DoesNotThrow(TestDelegate);
        }
        
        [Test]
        public void Constructor_NullChannel_ThrowsArgumentNullException()
        {
            // Arrange
            void TestDelegate()
            {
                new NotificationEvent(DefaultEventType, null, DefaultMessage);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(TestDelegate);
        }
        
        [Test]
        public void Constructor_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            void TestDelegate()
            {
                new NotificationEvent(DefaultEventType, DefaultChannel, null);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(TestDelegate);
        }
        
        [Theory]
        public void Data_GetsDeserializedData()
        {
            // Arrange
            var notificationEvent = CreateDefaultFakeNotificationEvent();
            
            Assume.That(notificationEvent.Message, Is.Not.Null.And.Not.Empty);
            
            // Act
            var actual = notificationEvent.Data;

            // Assert
            Assert.NotNull(actual);
        }

        private static NotificationEvent CreateDefaultFakeNotificationEvent() =>
            new NotificationEvent(DefaultEventType, DefaultChannel, DefaultMessage);
    }
}
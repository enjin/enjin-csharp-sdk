using Enjin.SDK.Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TestSuite
{
    [TestFixture]
    public class NotificationEventTest
    {
        private const EventType DefaultEventType = EventType.UNKNOWN;
        private const string DefaultChannel = "xyz";
        private const string DefaultMessage = @"{'name': 'value'}";
        
        [Test]
        public void Type_GetsValue()
        {
            // Arrange
            const EventType expected = DefaultEventType;
            var notificationEvent = CreateDefaultFakeNotificationEvent();

            // Act
            var actual = notificationEvent.Type;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Channel_GetsValue()
        {
            // Arrange
            const string expected = DefaultChannel;
            var notificationEvent = CreateDefaultFakeNotificationEvent();

            // Act
            var actual = notificationEvent.Channel;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Message_GetsValue()
        {
            // Arrange
            const string expected = DefaultMessage;
            var notificationEvent = CreateDefaultFakeNotificationEvent();

            // Act
            var actual = notificationEvent.Message;

            // Assert
            Assert.AreEqual(expected, actual);
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
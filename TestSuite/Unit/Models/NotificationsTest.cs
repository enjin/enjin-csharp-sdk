using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class NotificationsTest
    {
        private static readonly Pusher DEFAULT_PUSHER = new Pusher();

        [Test]
        public void Pusher_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_PUSHER;
            var notifications = CreateDefaultFakeNotifications();

            // Act
            var actual = notifications.Pusher;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static Notifications CreateDefaultFakeNotifications() =>
            new FakeNotifications(DEFAULT_PUSHER);

        private class FakeNotifications : Notifications
        {
            private static readonly PropertyInfo PUSHER_PROPERTY;

            static FakeNotifications()
            {
                var type = typeof(Notifications);
                PUSHER_PROPERTY = GetPublicProperty(type, "Pusher");
            }

            public FakeNotifications(Pusher pusher = null)
            {
                PUSHER_PROPERTY.SetValue(this, pusher);
            }
        }
    }
}
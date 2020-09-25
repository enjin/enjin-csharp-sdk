using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class PlatformTest
    {
        private static readonly Contracts DEFAULT_CONTRACTS = new Contracts();
        private static readonly Notifications DEFAULT_NOTIFICATIONS = new Notifications();

        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const int expected = FakePlatform.DefaultId;
            var platform = CreateDefaultFakePlatform();

            // Act
            var actual = platform.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Name_GetsValue()
        {
            // Arrange
            const string expected = FakePlatform.DefaultName;
            var platform = CreateDefaultFakePlatform();

            // Act
            var actual = platform.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Network_GetsValue()
        {
            // Arrange
            const string expected = FakePlatform.DefaultNetwork;
            var platform = CreateDefaultFakePlatform();

            // Act
            var actual = platform.Network;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Contracts_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_CONTRACTS;
            var platform = CreateDefaultFakePlatform();

            // Act
            var actual = platform.Contracts;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Notifications_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_NOTIFICATIONS;
            var platform = CreateDefaultFakePlatform();

            // Act
            var actual = platform.Notifications;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Platform CreateDefaultFakePlatform() =>
            new FakePlatform(contracts: DEFAULT_CONTRACTS, notifications: DEFAULT_NOTIFICATIONS);
        
        private class FakePlatform : Platform
        {
            public const int DefaultId = 1;
            public const string DefaultName = "DefaultName";
            public const string DefaultNetwork = "DefaultNetwork";
            
            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo NAME_PROPERTY;
            private static readonly PropertyInfo NETWORK_PROPERTY;
            private static readonly PropertyInfo CONTRACTS_PROPERTY;
            private static readonly PropertyInfo NOTIFICATIONS_PROPERTY;

            static FakePlatform()
            {
                var type = typeof(Platform);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                NAME_PROPERTY = GetPublicProperty(type, "Name");
                NETWORK_PROPERTY = GetPublicProperty(type, "Network");
                CONTRACTS_PROPERTY = GetPublicProperty(type, "Contracts");
                NOTIFICATIONS_PROPERTY = GetPublicProperty(type, "Notifications");
            }

            public FakePlatform(int id = DefaultId,
                                string name = DefaultName,
                                string network = DefaultNetwork,
                                Contracts contracts = null,
                                Notifications notifications = null)
            {
                ID_PROPERTY.SetValue(this, id);
                NAME_PROPERTY.SetValue(this, name);
                NETWORK_PROPERTY.SetValue(this, network);
                CONTRACTS_PROPERTY.SetValue(this, contracts);
                NOTIFICATIONS_PROPERTY.SetValue(this, notifications);
            }
        }
    }
}
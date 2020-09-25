using System.Reflection;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class PlayerTest
    {
        private static readonly JObject DEFAULT_WALLET = new JObject();
        
        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const string expected = FakePlayer.DefaultId;
            var player = CreateDefaultFakePlayer();

            // Act
            var actual = player.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void LinkingCode_GetsValue()
        {
            // Arrange
            const string expected = FakePlayer.DefaultLinkingCode;
            var player = CreateDefaultFakePlayer();

            // Act
            var actual = player.LinkingCode;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void LinkingCodeQr_GetsValue()
        {
            // Arrange
            const string expected = FakePlayer.DefaultLinkingCodeQr;
            var player = CreateDefaultFakePlayer();

            // Act
            var actual = player.LinkingCodeQr;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Wallet_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_WALLET;
            var player = CreateDefaultFakePlayer();

            // Act
            var actual = player.Wallet;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CreatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakePlayer.DefaultCreatedAt;
            var player = CreateDefaultFakePlayer();

            // Act
            var actual = player.CreatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void UpdatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakePlayer.DefaultUpdatedAt;
            var player = CreateDefaultFakePlayer();

            // Act
            var actual = player.UpdatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Player CreateDefaultFakePlayer() => new FakePlayer(wallet: DEFAULT_WALLET);
        
        private class FakePlayer : Player
        {
            public const string DefaultId = "DefaultId";
            public const string DefaultLinkingCode = "DefaultLinkingCode";
            public const string DefaultLinkingCodeQr = "DefaultLinkingCodeQr";
            public const string DefaultCreatedAt = "DefaultCreatedAt";
            public const string DefaultUpdatedAt = "DefaultUpdatedAt";
            
            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo LINKING_CODE_PROPERTY;
            private static readonly PropertyInfo LINKING_CODE_QR_PROPERTY;
            private static readonly PropertyInfo WALLET_PROPERTY;
            private static readonly PropertyInfo CREATED_AT_PROPERTY;
            private static readonly PropertyInfo UPDATED_AT_PROPERTY;

            static FakePlayer()
            {
                var type = typeof(Player);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                LINKING_CODE_PROPERTY = GetPublicProperty(type, "LinkingCode");
                LINKING_CODE_QR_PROPERTY = GetPublicProperty(type, "LinkingCodeQr");
                WALLET_PROPERTY = GetPublicProperty(type, "Wallet");
                CREATED_AT_PROPERTY = GetPublicProperty(type, "CreatedAt");
                UPDATED_AT_PROPERTY = GetPublicProperty(type, "UpdatedAt");
            }

            public FakePlayer(string id = DefaultId,
                              string linkingCode = DefaultLinkingCode,
                              string linkingCodeQr = DefaultLinkingCodeQr,
                              JObject wallet = null,
                              string createdAt = DefaultCreatedAt,
                              string updatedAt = DefaultUpdatedAt)
            {
                ID_PROPERTY.SetValue(this, id);
                LINKING_CODE_PROPERTY.SetValue(this, linkingCode);
                LINKING_CODE_QR_PROPERTY.SetValue(this, linkingCodeQr);
                WALLET_PROPERTY.SetValue(this, wallet);
                CREATED_AT_PROPERTY.SetValue(this, createdAt);
                UPDATED_AT_PROPERTY.SetValue(this, updatedAt);
            }
        }
    }
}
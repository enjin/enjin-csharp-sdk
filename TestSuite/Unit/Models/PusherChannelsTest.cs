using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherChannelsTest
    {
        [Test]
        public void Project_GetsValue()
        {
            // Arrange
            const string expected = FakePusherChannels.DefaultProject;
            var channels = CreateDefaultFakePusherChannels();

            // Act
            var actual = channels.Project;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Player_GetsValue()
        {
            // Arrange
            const string expected = FakePusherChannels.DefaultPlayer;
            var channels = CreateDefaultFakePusherChannels();

            // Act
            var actual = channels.Player;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Token_GetsValue()
        {
            // Arrange
            const string expected = FakePusherChannels.DefaultToken;
            var channels = CreateDefaultFakePusherChannels();

            // Act
            var actual = channels.Token;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Wallet_GetsValue()
        {
            // Arrange
            const string expected = FakePusherChannels.DefaultWallet;
            var channels = CreateDefaultFakePusherChannels();

            // Act
            var actual = channels.Wallet;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static PusherChannels CreateDefaultFakePusherChannels() => new FakePusherChannels();
        
        private class FakePusherChannels : PusherChannels
        {
            public const string DefaultProject = "DefaultProject";
            public const string DefaultPlayer = "DefaultPlayer";
            public const string DefaultToken = "DefaultToken";
            public const string DefaultWallet = "DefaultWallet";
            
            private static readonly PropertyInfo PROJECT_PROPERTY;
            private static readonly PropertyInfo PLAYER_PROPERTY;
            private static readonly PropertyInfo TOKEN_PROPERTY;
            private static readonly PropertyInfo WALLET_PROPERTY;
            
            static FakePusherChannels()
            {
                var type = typeof(PusherChannels);
                PROJECT_PROPERTY = GetPublicProperty(type, "Project");
                PLAYER_PROPERTY = GetPublicProperty(type, "Player");
                TOKEN_PROPERTY = GetPublicProperty(type, "Token");
                WALLET_PROPERTY = GetPublicProperty(type, "Wallet");
            }

            public FakePusherChannels(string project = DefaultProject,
                                      string player = DefaultPlayer,
                                      string token = DefaultToken,
                                      string wallet = DefaultWallet)
            {
                PROJECT_PROPERTY.SetValue(this, project);
                PLAYER_PROPERTY.SetValue(this, player);
                TOKEN_PROPERTY.SetValue(this, token);
                WALLET_PROPERTY.SetValue(this, wallet);
            }
        }
    }
}
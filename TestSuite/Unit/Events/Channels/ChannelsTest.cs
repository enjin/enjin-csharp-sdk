﻿using Enjin.SDK.Events;
using NUnit.Framework;
using static TestSuite.Utils.PlatformUtils;

namespace TestSuite
{
    [TestFixture]
    public class ChannelsTest
    {
        private const string DefaultPlatformName = "test";
        
        [Test]
        public void Channel_AppChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.app.1234";
            const int app = 1234;
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new AppChannel(fakePlatform, app);

            // Act
            var actual = channel.Channel();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Channel_PlayerChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.app.1234.player.player1";
            const int app = 1234;
            const string player = "player1";
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new PlayerChannel(fakePlatform, app, player);

            // Act
            var actual = channel.Channel();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Channel_TokenChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.token.0";
            const string token = "0";
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new TokenChannel(fakePlatform, token);

            // Act
            var actual = channel.Channel();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Channel_WalletChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.wallet.0";
            const string wallet = "0";
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new WalletChannel(fakePlatform, wallet);

            // Act
            var actual = channel.Channel();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
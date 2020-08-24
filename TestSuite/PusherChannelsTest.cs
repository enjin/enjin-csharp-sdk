using Enjin.SDK.Events;
using NUnit.Framework;
using static TestSuite.Utils.PlatformUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherChannelsTest
    {
        [Test]
        public void Channel_MultipleAppChannels_ReturnsCorrectString([Values("kovan", "mainnet")] string network,
                                                                     [Values(0, 1111)] int app)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var appChannel = new PusherAppChannel(platform, app);

            // Act
            var channel = appChannel.Channel();

            // Assert
            Assert.AreEqual($"enjincloud.{network}.app.{app}", channel);
        }

        [Test]
        public void Channel_MultiplePlayerChannels_ReturnsCorrectString([Values("kovan", "mainnet")] string network,
                                                                        [Values(0, 1111)] int app,
                                                                        [Values("player1", "player@email.com")]
                                                                        string player)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var playerChannel = new PusherPlayerChannel(platform, app, player);

            // Act
            var channel = playerChannel.Channel();

            // Assert
            Assert.AreEqual($"enjincloud.{network}.app.{app}.player.{player}", channel);
        }

        [Test]
        public void Channel_MultipleTokenChannels_ReturnsCorrectString([Values("kovan", "mainnet")] string network,
                                                                       [Values("0000000000000000")] string token)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var tokenChannel = new PusherTokenChannel(platform, token);

            // Act
            var channel = tokenChannel.Channel();

            // Assert
            Assert.AreEqual($"enjincloud.{network}.token.{token}", channel);
        }

        [Test]
        public void Channel_MultipleWalletChannels_ReturnsCorrectString([Values("kovan", "mainnet")] string network,
                                                                        [Values("0x0")] string wallet)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var walletChannel = new PusherWalletChannel(platform, wallet);

            // Act
            var channel = walletChannel.Channel();

            // Assert
            Assert.AreEqual($"enjincloud.{network}.wallet.{wallet}", channel);
        }
    }
}
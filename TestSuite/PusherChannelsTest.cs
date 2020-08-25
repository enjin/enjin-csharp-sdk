using Enjin.SDK.Events;
using NUnit.Framework;
using static TestSuite.Utils.PlatformUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherChannelsTest
    {
        [Test]
        [TestCase(Kovan, 1234, ExpectedResult = "enjincloud.kovan.app.1234")]
        [TestCase(Mainnet, 1234, ExpectedResult = "enjincloud.mainnet.app.1234")]
        public string Channel_MultipleAppChannels_ReturnsCorrectString(string network, int app)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var appChannel = new PusherAppChannel(platform, app);

            // Act
            var channel = appChannel.Channel();

            // Assert
            return channel;
        }

        [Test]
        [TestCase(Kovan, 1234, "player1", ExpectedResult = "enjincloud.kovan.app.1234.player.player1")]
        [TestCase(Mainnet, 1234, "player1", ExpectedResult = "enjincloud.mainnet.app.1234.player.player1")]
        [TestCase(Kovan, 1234, "player@email.com", ExpectedResult = "enjincloud.kovan.app.1234.player.player@email.com")]
        [TestCase(Mainnet, 1234, "player@email.com", ExpectedResult = "enjincloud.mainnet.app.1234.player.player@email.com")]
        public string Channel_MultiplePlayerChannels_ReturnsCorrectString(string network, int app, string player)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var playerChannel = new PusherPlayerChannel(platform, app, player);

            // Act
            var channel = playerChannel.Channel();

            // Assert
            return channel;
        }

        [Test]
        [TestCase(Kovan, "0000000000000000", ExpectedResult = "enjincloud.kovan.token.0000000000000000")]
        [TestCase(Mainnet, "0000000000000000", ExpectedResult = "enjincloud.mainnet.token.0000000000000000")]
        public string Channel_MultipleTokenChannels_ReturnsCorrectString(string network, string token)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var tokenChannel = new PusherTokenChannel(platform, token);

            // Act
            var channel = tokenChannel.Channel();

            // Assert
            return channel;
        }

        [Test]
        [TestCase(Kovan, "0x0", ExpectedResult = "enjincloud.kovan.wallet.0x0")]
        [TestCase(Mainnet, "0x0", ExpectedResult = "enjincloud.mainnet.wallet.0x0")]
        public string Channel_MultipleWalletChannels_ReturnsCorrectString(string network, string wallet)
        {
            // Arrange
            var platform = CreatePlatform(network);
            var walletChannel = new PusherWalletChannel(platform, wallet);

            // Act
            var channel = walletChannel.Channel();

            // Assert
            return channel;
        }
    }
}
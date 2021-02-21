using Enjin.SDK.Events;
using NUnit.Framework;
using static TestSuite.Utils.PlatformUtils;

namespace TestSuite
{
    [TestFixture]
    public class ChannelsTest
    {
        private const string DefaultPlatformName = "test";
        
        [Test]
        public void Channel_ProjectChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.project.1234";
            const int project = 1234;
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new ProjectChannel(fakePlatform, project);

            // Act
            var actual = channel.Channel();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Channel_PlayerChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.project.1234.player.player1";
            const int project = 1234;
            const string player = "player1";
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new PlayerChannel(fakePlatform, project, player);

            // Act
            var actual = channel.Channel();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Channel_AssetChannel_ReturnsExpectedString()
        {
            // Arrange
            const string expected = "enjincloud.test.asset.0";
            const string asset = "0";
            var fakePlatform = CreateFakePlatform(DefaultPlatformName);
            var channel = new AssetChannel(fakePlatform, asset);

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
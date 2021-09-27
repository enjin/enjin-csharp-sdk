/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
            const string expected = "enjincloud.test.project.xyz";
            const string project = "xyz";
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
            const string expected = "enjincloud.test.project.xyz.player.player1";
            const string project = "xyz";
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
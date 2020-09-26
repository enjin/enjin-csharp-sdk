using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class UnlinkWalletTest
    {
        [Test]
        public void EthAddress_ContainsValue()
        {
            // Arrange
            const string key = "ethAddress";
            const string expected = "0";
            var request = new UnlinkWallet();

            // Act
            request.EthAddress(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class SetTransferFeeTest
    {
        [Test]
        public void TokenId_ContainsValue()
        {
            // Arrange
            const string key = "tokenId";
            const string expected = "0";
            var request = new SetTransferFee();

            // Act
            request.TokenId(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenIndex_ContainsValue()
        {
            // Arrange
            const string key = "tokenIndex";
            const string expected = "0";
            var request = new SetTransferFee();

            // Act
            request.TokenIndex(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TransferFeeSettings_ContainsValue()
        {
            // Arrange
            const string key = "transferFeeSettings";
            var expected = new TokenTransferFeeSettingsInput();
            var request = new SetTransferFee();

            // Act
            request.TransferFeeSettings(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
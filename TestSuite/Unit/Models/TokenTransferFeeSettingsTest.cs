using Enjin.SDK.Models;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TokenTransferFeeSettingsTest
    {
        [Theory]
        public void Type_GetsValue(TokenTransferFeeType expected)
        {
            // Arrange
            var transferSettings = new TokenTransferFeeSettings {Type = expected};
            
            // Act
            var actual = transferSettings.Type;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenId_GetsValue()
        {
            // Arrange
            const string expected = "0";
            var transferSettings = new TokenTransferFeeSettings {TokenId = expected};
            
            // Act
            var actual = transferSettings.TokenId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_GetsValue()
        {
            // Arrange
            const string expected = "0";
            var transferSettings = new TokenTransferFeeSettings {Value = expected};
            
            // Act
            var actual = transferSettings.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
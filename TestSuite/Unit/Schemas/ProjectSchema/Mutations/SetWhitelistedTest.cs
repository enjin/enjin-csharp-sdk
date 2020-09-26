using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class SetWhitelistedTest
    {
        [Test]
        public void TokenId_ContainsValue()
        {
            // Arrange
            const string key = "tokenId";
            const string expected = "0";
            var request = new SetWhitelisted();

            // Act
            request.TokenId(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void AccountAddress_ContainsValue()
        {
            // Arrange
            const string key = "accountAddress";
            const string expected = "0";
            var request = new SetWhitelisted();

            // Act
            request.AccountAddress(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        public void Whitelisted_ContainsValue(Whitelisted expected)
        {
            // Arrange
            const string key = "whitelisted";
            var request = new SetWhitelisted();

            // Act
            request.Whitelisted(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void WhitelistedAddress_ContainsValue()
        {
            // Arrange
            const string key = "whitelistedAddress";
            const string expected = "0";
            var request = new SetWhitelisted();

            // Act
            request.WhitelistedAddress(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void On_ContainsValue()
        {
            // Arrange
            const string key = "on";
            const bool expected = true;
            var request = new SetWhitelisted();

            // Act
            request.On(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
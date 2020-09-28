using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class SendTokenTest
    {
        [Test]
        public void RecipientAddress_ContainsValue()
        {
            // Arrange
            const string key = "recipientAddress";
            const string expected = "0";
            var request = new SendToken();

            // Act
            request.RecipientAddress(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TokenId_ContainsValue()
        {
            // Arrange
            const string key = "tokenId";
            const string expected = "0";
            var request = new SendToken();

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
            var request = new SendToken();

            // Act
            request.TokenIndex(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_ContainsValue()
        {
            // Arrange
            const string key = "value";
            const string expected = "0";
            var request = new SendToken();

            // Act
            request.Value(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Data_ContainsValue()
        {
            // Arrange
            const string key = "data";
            const string expected = "0";
            var request = new SendToken();

            // Act
            request.Data(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
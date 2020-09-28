using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class SendEnjTest
    {
        [Test]
        public void RecipientAddress_ContainsValue()
        {
            // Arrange
            const string key = "recipientAddress";
            const string expected = "0";
            var request = new SendEnj();

            // Act
            request.RecipientAddress(expected);
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
            var request = new SendEnj();

            // Act
            request.Value(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
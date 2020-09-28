using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetRequestTest
    {
        [Test]
        public void Id_ContainsValue()
        {
            // Arrange
            const string key = "id";
            const int expected = 1;
            var request = new GetRequest();

            // Act
            request.Id(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TransactionId_ContainsValue()
        {
            // Arrange
            const string key = "transactionId";
            const string expected = "0";
            var request = new GetRequest();

            // Act
            request.TransactionId(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetRequestsTest
    {
        [Test]
        public void Filter_ContainsValue()
        {
            // Arrange
            const string key = "filter";
            var expected = new TransactionFilter();
            var request = new GetRequests();

            // Act
            request.Filter(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Sort_ContainsValue()
        {
            // Arrange
            const string key = "sort";
            var expected = new TransactionSort();
            var request = new GetRequests();

            // Act
            request.Sort(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
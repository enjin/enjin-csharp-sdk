using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetBalancesTest
    {
        [Test]
        public void Filter_ContainsValue()
        {
            // Arrange
            const string key = "filter";
            var expected = new BalanceFilter();
            var request = new GetBalances();

            // Act
            request.Filter(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
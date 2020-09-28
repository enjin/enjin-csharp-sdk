using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class CompleteTradeTest
    {
        [Test]
        public void TradeId_ContainsValue()
        {
            // Arrange
            const string key = "tradeId";
            const string expected = "0";
            var request = new CompleteTrade();

            // Act
            request.TradeId(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
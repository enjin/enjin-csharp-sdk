using System.Collections.Generic;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class CreateTradeTest
    {
        private static readonly List<Trade> TRADES = new List<Trade>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            TRADES.Add(new Trade());
            TRADES.Add(new Trade());
            TRADES.Add(new Trade());
        }
        
        [Test]
        public void AskingTokens_ContainsValue()
        {
            // Arrange
            const string key = "askingTokens";
            var expected = TRADES.ToArray();
            var request = new CreateTrade();

            // Act
            request.AskingTokens(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void OfferingTokens_ContainsValue()
        {
            // Arrange
            const string key = "offeringTokens";
            var expected = TRADES.ToArray();
            var request = new CreateTrade();

            // Act
            request.OfferingTokens(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RecipientAddress_ContainsValue()
        {
            // Arrange
            const string key = "recipientAddress";
            const string expected = "0";
            var request = new CreateTrade();

            // Act
            request.RecipientAddress(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
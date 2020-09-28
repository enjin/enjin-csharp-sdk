using System.Collections.Generic;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class AdvancedSendTokenTest
    {
        private static readonly List<Transfer> TRANSFERS = new List<Transfer>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            TRANSFERS.Add(new Transfer());
            TRANSFERS.Add(new Transfer());
            TRANSFERS.Add(new Transfer());
        }
        
        [Test]
        public void Transfers_ContainsValue()
        {
            // Arrange
            const string key = "transfers";
            var expected = TRANSFERS.ToArray();
            var request = new AdvancedSendToken();

            // Act
            request.Transfers(expected);
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
            var request = new AdvancedSendToken();

            // Act
            request.Data(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
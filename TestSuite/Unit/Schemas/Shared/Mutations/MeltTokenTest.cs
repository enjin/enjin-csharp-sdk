using System.Collections.Generic;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class MeltTokenTest
    {
        private static readonly List<Melt> MELTS = new List<Melt>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            MELTS.Add(new Melt());
            MELTS.Add(new Melt());
            MELTS.Add(new Melt());
        }
        
        [Test]
        public void Melts_ContainsValue()
        {
            // Arrange
            const string key = "melts";
            var expected = MELTS.ToArray();
            var request = new MeltToken();

            // Act
            request.Melts(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
using System.Collections.Generic;
using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class MintTokenTest
    {
        private static readonly List<MintInput> MINTS = new List<MintInput>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            MINTS.Add(new MintInput());
            MINTS.Add(new MintInput());
            MINTS.Add(new MintInput());
        }
        
        [Test]
        public void TokenId_ContainsValue()
        {
            // Arrange
            const string key = "tokenId";
            const string expected = "0";
            var request = new MintToken();

            // Act
            request.TokenId(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Mints_ContainsValue()
        {
            // Arrange
            const string key = "mints";
            var expected = MINTS;
            var request = new MintToken();

            // Act
            request.Mints(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
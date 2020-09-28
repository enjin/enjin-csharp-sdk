using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetTokensTest
    {
        [Test]
        public void Filter_ContainsValue()
        {
            // Arrange
            const string key = "filter";
            var expected = new TokenFilter();
            var request = new GetTokens();

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
            var expected = new TokenSort();
            var request = new GetTokens();

            // Act
            request.Sort(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
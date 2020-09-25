using Enjin.SDK.Models;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class PaginationOptionsTest
    {
        private const int DefaultPage = 1;
        private const int DefaultLimit = 2;

        [Test]
        public void Page_GetsValue()
        {
            // Arrange
            const int expected = DefaultPage;
            var options = CreateDefaultFakePaginationOptions();

            // Act
            var actual = options.Page;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Limit_GetsValue()
        {
            // Arrange
            const int expected = DefaultLimit;
            var options = CreateDefaultFakePaginationOptions();

            // Act
            var actual = options.Limit;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static PaginationOptions CreateDefaultFakePaginationOptions() => new PaginationOptions
        {
            Page = DefaultPage,
            Limit = DefaultLimit
        };
    }
}
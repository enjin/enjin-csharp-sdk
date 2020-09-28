using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetTokenTest
    {
        [Test]
        public void Id_ContainsValue()
        {
            // Arrange
            const string key = "id";
            const string expected = "0";
            var request = new GetToken();

            // Act
            request.Id(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
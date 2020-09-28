using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetProjectTest
    {
        [Test]
        public void Id_ContainsValue()
        {
            // Arrange
            const string key = "id";
            const int expected = 1;
            var request = new GetProject();

            // Act
            request.Id(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Name_ContainsValue()
        {
            // Arrange
            const string key = "name";
            const string expected = "0";
            var request = new GetProject();

            // Act
            request.Name(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
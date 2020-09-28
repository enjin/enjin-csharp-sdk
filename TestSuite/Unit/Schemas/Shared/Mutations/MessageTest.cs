using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class MessageTest
    {
        [Test]
        public void Constructor_ContainsValue()
        {
            // Arrange
            const string key = "message";
            const string expected = "0";

            // Act
            var request = new Message(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
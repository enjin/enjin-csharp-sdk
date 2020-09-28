using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class ApproveEnjTest
    {
        [Test]
        public void Value_ContainsValue()
        {
            // Arrange
            const string key = "value";
            const string expected = "0";
            var request = new ApproveEnj();

            // Act
            request.Value(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
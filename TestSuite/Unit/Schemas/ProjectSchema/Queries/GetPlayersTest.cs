using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetPlayersTest
    {
        [Test]
        public void Filter_ContainsValue()
        {
            // Arrange
            const string key = "filter";
            var expected = new PlayerFilter();
            var request = new GetPlayers();

            // Act
            request.Filter(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GetPlatformTest
    {
        [Test]
        public void WithContracts_ContainsValue()
        {
            // Arrange
            const string key = "withContracts";
            const bool expected = true;
            var request = new GetPlatform();

            // Act
            request.WithContracts();
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void WithNotificationDrivers_ContainsValue()
        {
            // Arrange
            const string key = "withNotificationDrivers";
            const bool expected = true;
            var request = new GetPlatform();

            // Act
            request.WithNotificationDrivers();
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
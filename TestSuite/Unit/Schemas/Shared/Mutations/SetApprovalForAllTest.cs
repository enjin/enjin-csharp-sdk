using Enjin.SDK.Shared;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class SetApprovalForAllTest
    {
        [Test]
        public void OperatorAddress_ContainsValue()
        {
            // Arrange
            const string key = "operatorAddress";
            const string expected = "0";
            var request = new SetApprovalForAll();

            // Act
            request.OperatorAddress(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Approved_ContainsValue()
        {
            // Arrange
            const string key = "approved";
            const bool expected = true;
            var request = new SetApprovalForAll();

            // Act
            request.Approved(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
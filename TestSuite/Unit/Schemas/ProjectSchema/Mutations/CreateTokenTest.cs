using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class CreateTokenTest
    {
        [Test]
        public void Name_ContainsValue()
        {
            // Arrange
            const string key = "name";
            const string expected = "0";
            var request = new CreateToken();

            // Act
            request.Name(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TotalSupply_ContainsValue()
        {
            // Arrange
            const string key = "totalSupply";
            const string expected = "0";
            var request = new CreateToken();

            // Act
            request.TotalSupply(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void InitialReserve_ContainsValue()
        {
            // Arrange
            const string key = "initialReserve";
            const string expected = "0";
            var request = new CreateToken();

            // Act
            request.InitialReserve(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        public void SupplyModel_ContainsValue(TokenSupplyModel expected)
        {
            // Arrange
            const string key = "supplyModel";
            var request = new CreateToken();

            // Act
            request.SupplyModel(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MeltValue_ContainsValue()
        {
            // Arrange
            const string key = "meltValue";
            const string expected = "0";
            var request = new CreateToken();

            // Act
            request.MeltValue(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MeltFeeRatio_ContainsValue()
        {
            // Arrange
            const string key = "meltFeeRatio";
            const int expected = 1;
            var request = new CreateToken();

            // Act
            request.MeltFeeRatio(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        public void Transferable_ContainsValue(TokenTransferable expected)
        {
            // Arrange
            const string key = "transferable";
            var request = new CreateToken();

            // Act
            request.Transferable(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TransferFeeSettings_ContainsValue()
        {
            // Arrange
            const string key = "transferFeeSettings";
            var expected = new TokenTransferFeeSettingsInput();
            var request = new CreateToken();

            // Act
            request.TransferFeeSettings(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Nonfungible_ContainsValue()
        {
            // Arrange
            const string key = "nonfungible";
            const bool expected = true;
            var request = new CreateToken();

            // Act
            request.Nonfungible(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class ContractsTest
    {
        private static readonly SupplyModels DEFAULT_SUPPLY_MODELS = new SupplyModels();

        [Test]
        public void Enj_GetsValue()
        {
            // Arrange
            const string expected = FakeContracts.DefaultEnj;
            var contracts = CreateDefaultFakeContracts();

            // Act
            var actual = contracts.Enj;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CryptoItems_GetsValue()
        {
            // Arrange
            const string expected = FakeContracts.DefaultCryptoItems;
            var contracts = CreateDefaultFakeContracts();

            // Act
            var actual = contracts.CryptoItems;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void PlatformRegistry_GetsValue()
        {
            // Arrange
            const string expected = FakeContracts.DefaultPlatformRegistry;
            var contracts = CreateDefaultFakeContracts();

            // Act
            var actual = contracts.PlatformRegistry;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SupplyModels_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_SUPPLY_MODELS;
            var contracts = CreateDefaultFakeContracts();

            // Act
            var actual = contracts.SupplyModels;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Contracts CreateDefaultFakeContracts() =>
            new FakeContracts(supplyModels: DEFAULT_SUPPLY_MODELS);

        private class FakeContracts : Contracts
        {
            public const string DefaultEnj = "DefaultEnj";
            public const string DefaultCryptoItems = "DefaultCryptoItems";
            public const string DefaultPlatformRegistry = "DefaultPlatformRegistry";

            private static readonly PropertyInfo ENJ_PROPERTY;
            private static readonly PropertyInfo CRYPTO_ITEMS_PROPERTY;
            private static readonly PropertyInfo PLATFORM_REGISTRY_PROPERTY;
            private static readonly PropertyInfo SUPPLY_MODELS_PROPERTY;

            static FakeContracts()
            {
                var type = typeof(Contracts);
                ENJ_PROPERTY = GetPublicProperty(type, "Enj");
                CRYPTO_ITEMS_PROPERTY = GetPublicProperty(type, "CryptoItems");
                PLATFORM_REGISTRY_PROPERTY = GetPublicProperty(type, "PlatformRegistry");
                SUPPLY_MODELS_PROPERTY = GetPublicProperty(type, "SupplyModels");
            }

            public FakeContracts(string enj = DefaultEnj,
                                 string cryptoItems = DefaultCryptoItems,
                                 string platformRegistry = DefaultPlatformRegistry,
                                 SupplyModels supplyModels = null)
            {
                ENJ_PROPERTY.SetValue(this, enj);
                CRYPTO_ITEMS_PROPERTY.SetValue(this, cryptoItems);
                PLATFORM_REGISTRY_PROPERTY.SetValue(this, platformRegistry);
                SUPPLY_MODELS_PROPERTY.SetValue(this, supplyModels);
            }
        }
    }
}
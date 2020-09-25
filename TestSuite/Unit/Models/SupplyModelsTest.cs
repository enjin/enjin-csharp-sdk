using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class SupplyModelsTest
    {
        [Test]
        public void Fixed_GetsValue()
        {
            // Arrange
            const string expected = FakeSupplyModels.DefaultFixed;
            var supplyModels = CreateDefaultFakeSupplyModels();

            // Act
            var actual = supplyModels.Fixed;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Settable_GetsValue()
        {
            // Arrange
            const string expected = FakeSupplyModels.DefaultSettable;
            var supplyModels = CreateDefaultFakeSupplyModels();

            // Act
            var actual = supplyModels.Settable;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Infinite_GetsValue()
        {
            // Arrange
            const string expected = FakeSupplyModels.DefaultInfinite;
            var supplyModels = CreateDefaultFakeSupplyModels();

            // Act
            var actual = supplyModels.Infinite;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Collapsing_GetsValue()
        {
            // Arrange
            const string expected = FakeSupplyModels.DefaultCollapsing;
            var supplyModels = CreateDefaultFakeSupplyModels();

            // Act
            var actual = supplyModels.Collapsing;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void AnnualValue_GetsValue()
        {
            // Arrange
            const string expected = FakeSupplyModels.DefaultAnnualValue;
            var supplyModels = CreateDefaultFakeSupplyModels();

            // Act
            var actual = supplyModels.AnnualValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void AnnualPercentage_GetsValue()
        {
            // Arrange
            const string expected = FakeSupplyModels.DefaultAnnualPercentage;
            var supplyModels = CreateDefaultFakeSupplyModels();

            // Act
            var actual = supplyModels.AnnualPercentage;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static SupplyModels CreateDefaultFakeSupplyModels() => new FakeSupplyModels();

        private class FakeSupplyModels : SupplyModels
        {
            public const string DefaultFixed = "DefaultFixed";
            public const string DefaultSettable = "DefaultSettable";
            public const string DefaultInfinite = "DefaultInfinite";
            public const string DefaultCollapsing = "DefaultCollapsing";
            public const string DefaultAnnualValue = "DefaultAnnualValue";
            public const string DefaultAnnualPercentage = "DefaultAnnualPercentage";
            
            private static readonly PropertyInfo FIXED_PROPERTY;
            private static readonly PropertyInfo SETTABLE_PROPERTY;
            private static readonly PropertyInfo INFINITE_PROPERTY;
            private static readonly PropertyInfo COLLAPSING_PROPERTY;
            private static readonly PropertyInfo ANNUAL_VALUE_PROPERTY;
            private static readonly PropertyInfo ANNUAL_PERCENTAGE_PROPERTY;

            static FakeSupplyModels()
            {
                var type = typeof(SupplyModels);
                FIXED_PROPERTY = GetPublicProperty(type, "Fixed");
                SETTABLE_PROPERTY = GetPublicProperty(type, "Settable");
                INFINITE_PROPERTY = GetPublicProperty(type, "Infinite");
                COLLAPSING_PROPERTY = GetPublicProperty(type, "Collapsing");
                ANNUAL_VALUE_PROPERTY = GetPublicProperty(type, "AnnualValue");
                ANNUAL_PERCENTAGE_PROPERTY = GetPublicProperty(type, "AnnualPercentage");
            }

            public FakeSupplyModels(string @fixed = DefaultFixed,
                                    string settable = DefaultSettable,
                                    string infinite = DefaultInfinite,
                                    string collapsing = DefaultCollapsing,
                                    string annualValue = DefaultAnnualValue,
                                    string annualPercentage = DefaultAnnualPercentage)
            {
                FIXED_PROPERTY.SetValue(this, @fixed);
                SETTABLE_PROPERTY.SetValue(this, settable);
                INFINITE_PROPERTY.SetValue(this, infinite);
                COLLAPSING_PROPERTY.SetValue(this, collapsing);
                ANNUAL_VALUE_PROPERTY.SetValue(this, annualValue);
                ANNUAL_PERCENTAGE_PROPERTY.SetValue(this, annualPercentage);
            }
        }
    }
}
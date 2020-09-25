using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class GasPricesTest
    {
        [Test]
        public void SafeLow_GetsValue()
        {
            // Arrange
            const float expected = FakeGasPrices.DefaultSafeLow;
            var gasPrices = CreateDefaultFakeGasPrices();

            // Act
            var actual = gasPrices.SafeLow;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Average_GetsValue()
        {
            // Arrange
            const float expected = FakeGasPrices.DefaultAverage;
            var gasPrices = CreateDefaultFakeGasPrices();

            // Act
            var actual = gasPrices.Average;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Fast_GetsValue()
        {
            // Arrange
            const float expected = FakeGasPrices.DefaultFast;
            var gasPrices = CreateDefaultFakeGasPrices();

            // Act
            var actual = gasPrices.Fast;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Fastest_GetsValue()
        {
            // Arrange
            const float expected = FakeGasPrices.DefaultFastest;
            var gasPrices = CreateDefaultFakeGasPrices();

            // Act
            var actual = gasPrices.Fastest;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static GasPrices CreateDefaultFakeGasPrices() => new FakeGasPrices();
        
        private class FakeGasPrices : GasPrices
        {
            public const float DefaultSafeLow = 1.0f;
            public const float DefaultAverage = 2.0f;
            public const float DefaultFast = 3.0f;
            public const float DefaultFastest = 4.0f;
            
            private static readonly PropertyInfo SAFE_LOW_PROPERTY;
            private static readonly PropertyInfo AVERAGE_PROPERTY;
            private static readonly PropertyInfo FAST_PROPERTY;
            private static readonly PropertyInfo FASTEST_PROPERTY;

            static FakeGasPrices()
            {
                var type = typeof(GasPrices);
                SAFE_LOW_PROPERTY = GetPublicProperty(type, "SafeLow");
                AVERAGE_PROPERTY = GetPublicProperty(type, "Average");
                FAST_PROPERTY = GetPublicProperty(type, "Fast");
                FASTEST_PROPERTY = GetPublicProperty(type, "Fastest");
            }

            public FakeGasPrices(float safeLow = DefaultSafeLow,
                                 float average = DefaultAverage,
                                 float fast = DefaultFast,
                                 float fastest = DefaultFastest)
            {
                SAFE_LOW_PROPERTY.SetValue(this, safeLow);
                AVERAGE_PROPERTY.SetValue(this, average);
                FAST_PROPERTY.SetValue(this, fast);
                FASTEST_PROPERTY.SetValue(this, fastest);
            }
        }
    }
}
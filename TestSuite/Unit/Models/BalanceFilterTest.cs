using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class BalanceFilterTest
    {
        private static readonly List<string> IDS = new List<string>();
        
        [OneTimeSetUp]
        public static void BeforeAll()
        {
            IDS.Add("1");
            IDS.Add("2");
            IDS.Add("3");
        }
        
        [Test]
        public void AssetIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableBalanceFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.AssetIdIn(args);
            var actual = filter.GetAssetIdIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void AssetIdIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableBalanceFilter();

            // Act
            filter.AssetIdIn();
            var actual = filter.GetAssetIdIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void AssetIdIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableBalanceFilter();

            // Act
            filter.AssetIdIn(null);
            var actual = filter.GetAssetIdIn();

            // Assert
            Assert.Null(actual);
        }
        
        [Test]
        public void WalletIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableBalanceFilter();
            
            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.WalletIn(args);
            var actual = filter.GetWalletIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void WalletIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableBalanceFilter();
            
            // Act
            filter.WalletIn();
            var actual = filter.GetWalletIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void WalletIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableBalanceFilter();
            
            // Act
            filter.WalletIn(null);
            var actual = filter.GetWalletIn();

            // Assert
            Assert.Null(actual);
        }
        
        private class TestableBalanceFilter : BalanceFilter
        {
            private static readonly FieldInfo ASSET_ID_IN_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableBalanceFilter()
            {
                var type = typeof(BalanceFilter);
                ASSET_ID_IN_FIELD = GetPrivateAttribute(type, "_assetIdIn");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }

            public List<string> GetAssetIdIn() => ASSET_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
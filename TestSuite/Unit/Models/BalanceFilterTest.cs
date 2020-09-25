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
        public void TokenId_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableBalanceFilter();

            // Act
            filter.TokenId(expected);
            var actual = filter.GetTokenId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        public void TokenIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableBalanceFilter();

            Assume.That(args, Is.Not.Empty);
            
            // Act
            filter.TokenIdIn(args);
            var actual = filter.GetTokenIdIn();

            // Assert
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void Wallet_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableBalanceFilter();

            // Act
            filter.Wallet(expected);
            var actual = filter.GetWallet();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        public void WalletIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableBalanceFilter();
            
            Assume.That(args, Is.Not.Empty);
            
            // Act
            filter.WalletIn(args);
            var actual = filter.GetWalletIn();

            // Assert
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void Value_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableBalanceFilter();

            // Act
            filter.Value(expected);
            var actual = filter.GetValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueGreaterThan_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableBalanceFilter();

            // Act
            filter.ValueGreaterThan(expected);
            var actual = filter.GetValueGreaterThan();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueGreaterThanOrEqual_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableBalanceFilter();

            // Act
            filter.ValueGreaterThanOrEqual(expected);
            var actual = filter.GetValueGreaterThanOrEqual();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueLessThan_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableBalanceFilter();

            // Act
            filter.ValueLessThan(expected);
            var actual = filter.GetValueLessThan();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueLessThanOrEqual_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableBalanceFilter();

            // Act
            filter.ValueLessThanOrEqual(expected);
            var actual = filter.GetValueLessThanOrEqual();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private class TestableBalanceFilter : BalanceFilter
        {
            private static readonly FieldInfo TOKEN_ID_FIELD;
            private static readonly FieldInfo TOKEN_ID_IN_FIELD;
            private static readonly FieldInfo WALLET_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;
            private static readonly FieldInfo VALUE_FIELD;
            private static readonly FieldInfo VALUE_GT_FIELD;
            private static readonly FieldInfo VALUE_GTE_FIELD;
            private static readonly FieldInfo VALUE_LT_FIELD;
            private static readonly FieldInfo VALUE_LTE_FIELD;

            static TestableBalanceFilter()
            {
                var type = typeof(BalanceFilter);
                TOKEN_ID_FIELD = GetPrivateAttribute(type, "_tokenId");
                TOKEN_ID_IN_FIELD = GetPrivateAttribute(type, "_tokenIdIn");
                WALLET_FIELD = GetPrivateAttribute(type, "_wallet");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
                VALUE_FIELD = GetPrivateAttribute(type, "_value");
                VALUE_GT_FIELD = GetPrivateAttribute(type, "_valueGt");
                VALUE_GTE_FIELD = GetPrivateAttribute(type, "_valueGte");
                VALUE_LT_FIELD = GetPrivateAttribute(type, "_valueLt");
                VALUE_LTE_FIELD = GetPrivateAttribute(type, "_valueLte");
            }

            public string GetTokenId() => (string) TOKEN_ID_FIELD.GetValue(this);

            public List<string> GetTokenIdIn() => TOKEN_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public string GetWallet() => WALLET_FIELD.GetValue(this) as string;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
            
            public int? GetValue() => VALUE_FIELD.GetValue(this) as int?;
            
            public int? GetValueGreaterThan() => VALUE_GT_FIELD.GetValue(this) as int?;
            
            public int? GetValueGreaterThanOrEqual() => VALUE_GTE_FIELD.GetValue(this) as int?;
            
            public int? GetValueLessThan() => VALUE_LT_FIELD.GetValue(this) as int?;
            
            public int? GetValueLessThanOrEqual() => VALUE_LTE_FIELD.GetValue(this) as int?;
        }
    }
}
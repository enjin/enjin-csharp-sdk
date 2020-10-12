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
        
        private class TestableBalanceFilter : BalanceFilter
        {
            private static readonly FieldInfo TOKEN_ID_IN_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableBalanceFilter()
            {
                var type = typeof(BalanceFilter);
                TOKEN_ID_IN_FIELD = GetPrivateAttribute(type, "_tokenIdIn");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }

            public List<string> GetTokenIdIn() => TOKEN_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
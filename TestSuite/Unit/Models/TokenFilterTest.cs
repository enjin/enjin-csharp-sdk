using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TokenFilterTest
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
        public void IdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTokenFilter();

            Assume.That(args, Is.Not.Empty);
            
            // Act
            filter.IdIn(args);
            var actual = filter.GetIdIn();

            // Assert
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Theory]
        public void NameIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTokenFilter();

            Assume.That(args, Is.Not.Empty);
            
            // Act
            filter.NameIn(args);
            var actual = filter.GetNameIn();

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
            var filter = new TestableTokenFilter();

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
        
        private class TestableTokenFilter : TokenFilter
        {
            private static readonly FieldInfo ID_IN_FIELD;
            private static readonly FieldInfo NAME_IN_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableTokenFilter()
            {
                var type = typeof(TokenFilter);
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
                NAME_IN_FIELD = GetPrivateAttribute(type, "_nameIn");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }
            
            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetNameIn() => NAME_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
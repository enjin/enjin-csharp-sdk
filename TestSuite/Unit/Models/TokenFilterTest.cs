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

        [Test]
        public void Id_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTokenFilter();

            // Act
            filter.Id(expected);
            var actual = filter.GetId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void IdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTokenFilter();

            // Act
            filter.IdIn(args);
            var actual = filter.GetIdIn();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void Name_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTokenFilter();

            // Act
            filter.Name(expected);
            var actual = filter.GetName();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void NameContains_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTokenFilter();

            // Act
            filter.NameContains(expected);
            var actual = filter.GetNameContains();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void NameIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTokenFilter();

            // Act
            filter.NameIn(args);
            var actual = filter.GetNameIn();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void NameStartsWith_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTokenFilter();

            // Act
            filter.NameStartsWith(expected);
            var actual = filter.GetNameStartsWith();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void NameEndsWith_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTokenFilter();

            // Act
            filter.NameEndsWith(expected);
            var actual = filter.GetNameEndsWith();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Wallet_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTokenFilter();

            // Act
            filter.Wallet(expected);
            var actual = filter.GetWallet();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void WalletIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTokenFilter();

            // Act
            filter.WalletIn(args);
            var actual = filter.GetWalletIn();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        private class TestableTokenFilter : TokenFilter
        {
            private static readonly FieldInfo ID_FIELD;
            private static readonly FieldInfo ID_IN_FIELD;
            private static readonly FieldInfo NAME_FIELD;
            private static readonly FieldInfo NAME_CONTAINS_FIELD;
            private static readonly FieldInfo NAME_IN_FIELD;
            private static readonly FieldInfo NAME_STARTS_WITH_FIELD;
            private static readonly FieldInfo NAME_ENDS_WITH_FIELD;
            private static readonly FieldInfo WALLET_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableTokenFilter()
            {
                var type = typeof(TokenFilter);
                ID_FIELD = GetPrivateAttribute(type, "_id");
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
                NAME_FIELD = GetPrivateAttribute(type, "_name");
                NAME_CONTAINS_FIELD = GetPrivateAttribute(type, "_nameContains");
                NAME_IN_FIELD = GetPrivateAttribute(type, "_nameIn");
                NAME_STARTS_WITH_FIELD = GetPrivateAttribute(type, "_nameStartsWith");
                NAME_ENDS_WITH_FIELD = GetPrivateAttribute(type, "_nameEndsWith");
                WALLET_FIELD = GetPrivateAttribute(type, "_wallet");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }

            public string GetId() => ID_FIELD.GetValue(this) as string;
            
            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
            
            public string GetName() => NAME_FIELD.GetValue(this) as string;
            
            public string GetNameContains() => NAME_CONTAINS_FIELD.GetValue(this) as string;
            
            public List<string> GetNameIn() => NAME_IN_FIELD.GetValue(this) as List<string>;
            
            public string GetNameStartsWith() => NAME_STARTS_WITH_FIELD.GetValue(this) as string;
            
            public string GetNameEndsWith() => NAME_ENDS_WITH_FIELD.GetValue(this) as string;
            
            public string GetWallet() => WALLET_FIELD.GetValue(this) as string;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
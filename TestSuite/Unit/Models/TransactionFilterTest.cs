using System;
using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TransactionFilterTest
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
            var filter = new TestableTransactionFilter();

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
            var filter = new TestableTransactionFilter();

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
        public void TransactionId_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTransactionFilter();

            // Act
            filter.TransactionId(expected);
            var actual = filter.GetTransactionId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TransactionIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

            // Act
            filter.TransactionIdIn(args);
            var actual = filter.GetTransactionIdIn();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void TokenId_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTransactionFilter();

            // Act
            filter.TokenId(expected);
            var actual = filter.GetTokenId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

            // Act
            filter.TokenIdIn(args);
            var actual = filter.GetTokenIdIn();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        [Theory]
        public void Type_PassedArguments_FieldContainsArgument(RequestType expected)
        {
            // Arrange
            var filter = new TestableTransactionFilter();

            // Act
            filter.Type(expected);
            var actual = filter.GetType();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Types_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = (RequestType[]) Enum.GetValues(typeof(RequestType));
            var filter = new TestableTransactionFilter();

            // Act
            filter.Types(args);
            var actual = filter.GetTypes();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void Value_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableTransactionFilter();

            // Act
            filter.Value(expected);
            var actual = filter.GetValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueGreaterThan_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableTransactionFilter();

            // Act
            filter.ValueGreaterThan(expected);
            var actual = filter.GetValueGreaterThan();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueGreaterThanOrEqual_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableTransactionFilter();

            // Act
            filter.ValueGreaterThanOrEqual(expected);
            var actual = filter.GetValueGreaterThanOrEqual();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueLessThan_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableTransactionFilter();

            // Act
            filter.ValueLessThan(expected);
            var actual = filter.GetValueLessThan();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ValueLessThanOrEqual_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const int expected = 1;
            var filter = new TestableTransactionFilter();

            // Act
            filter.ValueLessThanOrEqual(expected);
            var actual = filter.GetValueLessThanOrEqual();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        [Theory]
        public void State_PassedArguments_FieldContainsArgument(RequestState expected)
        {
            // Arrange
            var filter = new TestableTransactionFilter();

            // Act
            filter.State(expected);
            var actual = filter.GetState();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void StateIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = (RequestState[]) Enum.GetValues(typeof(RequestState));
            var filter = new TestableTransactionFilter();

            // Act
            filter.StateIn(args);
            var actual = filter.GetStateIn();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }
        
        [Test]
        public void Wallet_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestableTransactionFilter();

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
            var filter = new TestableTransactionFilter();

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
        
        private class TestableTransactionFilter : TransactionFilter
        {
            private static readonly FieldInfo ID_FIELD;
            private static readonly FieldInfo ID_IN_FIELD;
            private static readonly FieldInfo TRANSACTION_ID_FIELD;
            private static readonly FieldInfo TRANSACTION_ID_IN_FIELD;
            private static readonly FieldInfo TOKEN_ID_FIELD;
            private static readonly FieldInfo TOKEN_ID_IN_FIELD;
            private static readonly FieldInfo TYPE_FIELD;
            private static readonly FieldInfo TYPE_IN_FIELD;
            private static readonly FieldInfo VALUE_FIELD;
            private static readonly FieldInfo VALUE_GT_FIELD;
            private static readonly FieldInfo VALUE_GTE_FIELD;
            private static readonly FieldInfo VALUE_LT_FIELD;
            private static readonly FieldInfo VALUE_LTE_FIELD;
            private static readonly FieldInfo STATE_FIELD;
            private static readonly FieldInfo STATE_IN_FIELD;
            private static readonly FieldInfo WALLET_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableTransactionFilter()
            {
                var type = typeof(TransactionFilter);
                ID_FIELD = GetPrivateAttribute(type, "_id");
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
                TRANSACTION_ID_FIELD = GetPrivateAttribute(type, "_transactionId");
                TRANSACTION_ID_IN_FIELD = GetPrivateAttribute(type, "_transactionIdIn");
                TOKEN_ID_FIELD = GetPrivateAttribute(type, "_tokenId");
                TOKEN_ID_IN_FIELD = GetPrivateAttribute(type, "_tokenIdIn");
                TYPE_FIELD = GetPrivateAttribute(type, "_type");
                TYPE_IN_FIELD = GetPrivateAttribute(type, "_typeIn");
                VALUE_FIELD = GetPrivateAttribute(type, "_value");
                VALUE_GT_FIELD = GetPrivateAttribute(type, "_valueGt");
                VALUE_GTE_FIELD = GetPrivateAttribute(type, "_valueGte");
                VALUE_LT_FIELD = GetPrivateAttribute(type, "_valueLt");
                VALUE_LTE_FIELD = GetPrivateAttribute(type, "_valueLte");
                STATE_FIELD = GetPrivateAttribute(type, "_state");
                STATE_IN_FIELD = GetPrivateAttribute(type, "_stateIn");
                WALLET_FIELD = GetPrivateAttribute(type, "_wallet");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }

            public string GetId() => ID_FIELD.GetValue(this) as string;
            
            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
            
            public string GetTransactionId() => TRANSACTION_ID_FIELD.GetValue(this) as string;
            
            public List<string> GetTransactionIdIn() => TRANSACTION_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public string GetTokenId() => TOKEN_ID_FIELD.GetValue(this) as string;
            
            public List<string> GetTokenIdIn() => TOKEN_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public new RequestType GetType() => (RequestType) TYPE_FIELD.GetValue(this);
            
            public List<RequestType> GetTypes() => TYPE_IN_FIELD.GetValue(this) as List<RequestType>;
            
            public int? GetValue() => VALUE_FIELD.GetValue(this) as int?;
            
            public int? GetValueGreaterThan() => VALUE_GT_FIELD.GetValue(this) as int?;
            
            public int? GetValueGreaterThanOrEqual() => VALUE_GTE_FIELD.GetValue(this) as int?;
            
            public int? GetValueLessThan() => VALUE_LT_FIELD.GetValue(this) as int?;
            
            public int? GetValueLessThanOrEqual() => VALUE_LTE_FIELD.GetValue(this) as int?;
            
            public RequestState GetState() => (RequestState) STATE_FIELD.GetValue(this);
            
            public List<RequestState> GetStateIn() => STATE_IN_FIELD.GetValue(this) as List<RequestState>;
            
            public string GetWallet() => WALLET_FIELD.GetValue(this) as string;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
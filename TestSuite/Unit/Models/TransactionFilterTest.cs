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
        public void IdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.IdIn(args);
            var actual = filter.GetIdIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void IdIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.IdIn();
            var actual = filter.GetIdIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void IdIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.IdIn(null);
            var actual = filter.GetIdIn();

            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void TransactionIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.TransactionIdIn(args);
            var actual = filter.GetTransactionIdIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void TransactionIdIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.TransactionIdIn();
            var actual = filter.GetTransactionIdIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void TransactionIdIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.TransactionIdIn(null);
            var actual = filter.GetTransactionIdIn();

            // Assert
            Assert.Null(actual);
        }
        
        [Test]
        public void TokenIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.TokenIdIn(args);
            var actual = filter.GetTokenIdIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void TokenIdIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.TokenIdIn();
            var actual = filter.GetTokenIdIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void TokenIdIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.TransactionIdIn(null);
            var actual = filter.GetTransactionIdIn();

            // Assert
            Assert.Null(actual);
        }
        
        [Test]
        public void Types_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = (RequestType[]) Enum.GetValues(typeof(RequestType));
            var filter = new TestableTransactionFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.Types(args);
            var actual = filter.GetTypes();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void Types_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.Types();
            var actual = filter.GetTypes();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void Types_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.Types(null);
            var actual = filter.GetTypes();

            // Assert
            Assert.Null(actual);
        }
        
        [Test]
        public void StateIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = (RequestState[]) Enum.GetValues(typeof(RequestState));
            var filter = new TestableTransactionFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.StateIn(args);
            var actual = filter.GetStateIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void StateIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.StateIn();
            var actual = filter.GetStateIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void StateIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.StateIn(null);
            var actual = filter.GetStateIn();

            // Assert
            Assert.Null(actual);
        }
        
        [Test]
        public void WalletIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

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
            var filter = new TestableTransactionFilter();
            
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
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.WalletIn(null);
            var actual = filter.GetWalletIn();

            // Assert
            Assert.Null(actual);
        }
        
        private class TestableTransactionFilter : TransactionFilter
        {
            private static readonly FieldInfo ID_IN_FIELD;
            private static readonly FieldInfo TRANSACTION_ID_IN_FIELD;
            private static readonly FieldInfo TOKEN_ID_IN_FIELD;
            private static readonly FieldInfo TYPE_IN_FIELD;
            private static readonly FieldInfo STATE_IN_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableTransactionFilter()
            {
                var type = typeof(TransactionFilter);
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
                TRANSACTION_ID_IN_FIELD = GetPrivateAttribute(type, "_transactionIdIn");
                TOKEN_ID_IN_FIELD = GetPrivateAttribute(type, "_tokenIdIn");
                TYPE_IN_FIELD = GetPrivateAttribute(type, "_typeIn");
                STATE_IN_FIELD = GetPrivateAttribute(type, "_stateIn");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }
            
            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetTransactionIdIn() => TRANSACTION_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetTokenIdIn() => TOKEN_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<RequestType> GetTypes() => TYPE_IN_FIELD.GetValue(this) as List<RequestType>;
            
            public List<RequestState> GetStateIn() => STATE_IN_FIELD.GetValue(this) as List<RequestState>;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
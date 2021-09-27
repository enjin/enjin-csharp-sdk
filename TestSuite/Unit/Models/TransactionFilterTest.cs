/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
        public void AssetIdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableTransactionFilter();

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
            var filter = new TestableTransactionFilter();
            
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
            var filter = new TestableTransactionFilter();
            
            // Act
            filter.AssetIdIn(null);
            var actual = filter.GetAssetIdIn();

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
            private static readonly FieldInfo ASSET_ID_IN_FIELD;
            private static readonly FieldInfo TYPE_IN_FIELD;
            private static readonly FieldInfo STATE_IN_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableTransactionFilter()
            {
                var type = typeof(TransactionFilter);
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
                TRANSACTION_ID_IN_FIELD = GetPrivateAttribute(type, "_transactionIdIn");
                ASSET_ID_IN_FIELD = GetPrivateAttribute(type, "_assetIdIn");
                TYPE_IN_FIELD = GetPrivateAttribute(type, "_typeIn");
                STATE_IN_FIELD = GetPrivateAttribute(type, "_stateIn");
                WALLET_IN_FIELD = GetPrivateAttribute(type, "_walletIn");
            }
            
            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetTransactionIdIn() => TRANSACTION_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<string> GetAssetIdIn() => ASSET_ID_IN_FIELD.GetValue(this) as List<string>;
            
            public List<RequestType> GetTypes() => TYPE_IN_FIELD.GetValue(this) as List<RequestType>;
            
            public List<RequestState> GetStateIn() => STATE_IN_FIELD.GetValue(this) as List<RequestState>;
            
            public List<string> GetWalletIn() => WALLET_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
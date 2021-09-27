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

using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class AssetFilterTest
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
            var filter = new TestableAssetFilter();

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
            var filter = new TestableAssetFilter();
            
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
            var filter = new TestableAssetFilter();
            
            // Act
            filter.IdIn(null);
            var actual = filter.GetIdIn();

            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void NameIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableAssetFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.NameIn(args);
            var actual = filter.GetNameIn();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void NameIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableAssetFilter();

            // Act
            filter.NameIn();
            var actual = filter.GetNameIn();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void NameIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableAssetFilter();
            
            // Act
            filter.NameIn(null);
            var actual = filter.GetNameIn();

            // Assert
            Assert.Null(actual);
        }
        
        [Test]
        public void WalletIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestableAssetFilter();

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
            var filter = new TestableAssetFilter();
            
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
            var filter = new TestableAssetFilter();

            // Act
            filter.WalletIn(null);
            var actual = filter.GetWalletIn();

            // Assert
            Assert.Null(actual);
        }
        
        private class TestableAssetFilter : AssetFilter
        {
            private static readonly FieldInfo ID_IN_FIELD;
            private static readonly FieldInfo NAME_IN_FIELD;
            private static readonly FieldInfo WALLET_IN_FIELD;

            static TestableAssetFilter()
            {
                var type = typeof(AssetFilter);
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
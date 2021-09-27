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
    public class FilterTest
    {
        private static readonly List<TestableFilter> FILTERS = new List<TestableFilter>();
        
        [OneTimeSetUp]
        public static void BeforeAll()
        {
            FILTERS.Add(new TestableFilter());
            FILTERS.Add(new TestableFilter());
            FILTERS.Add(new TestableFilter());
        }
        
        [Test]
        public void And_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = FILTERS.ToArray();
            var filter = new TestableFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.And(args);
            var actual = filter.GetAnd();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void And_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableFilter();
            
            // Act
            filter.And();
            var actual = filter.GetAnd();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void And_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableFilter();
            
            // Act
            filter.And(null);
            var actual = filter.GetAnd();

            // Assert
            Assert.Null(actual);
        }

        [Test]
        public void Or_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = FILTERS.ToArray();
            var filter = new TestableFilter();

            Assume.That(args, Is.Not.Null.And.Not.Empty);
            
            // Act
            filter.Or(args);
            var actual = filter.GetOr();

            // Assert
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void Or_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestableFilter();
            
            // Act
            filter.Or();
            var actual = filter.GetOr();

            // Assert
            Assert.That(actual, Is.Not.Null.And.Empty);
        }

        [Test]
        public void Or_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestableFilter();
            
            // Act
            filter.Or(null);
            var actual = filter.GetOr();

            // Assert
            Assert.Null(actual);
        }
        
        private class TestableFilter : Filter<TestableFilter>
        {
            private static readonly FieldInfo AND_FIELD;
            private static readonly FieldInfo OR_FIELD;
            
            static TestableFilter()
            {
                var type = typeof(Filter<TestableFilter>);
                AND_FIELD = GetPrivateAttribute(type, "_and");
                OR_FIELD = GetPrivateAttribute(type, "_or");
            }

            public List<TestableFilter> GetAnd() => AND_FIELD.GetValue(this) as List<TestableFilter>;
            
            public List<TestableFilter> GetOr() => OR_FIELD.GetValue(this) as List<TestableFilter>;
        }
    }
}
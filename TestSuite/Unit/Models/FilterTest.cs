﻿using System.Collections.Generic;
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

            // Act
            filter.And(args);
            var actual = filter.GetAnd();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
        }

        [Test]
        public void Or_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = FILTERS.ToArray();
            var filter = new TestableFilter();

            // Act
            filter.Or(args);
            var actual = filter.GetOr();

            // Assert
            Assume.That(args.Length > 0);
            Assert.NotNull(actual);
            foreach (var expected in args)
            {
                Assert.Contains(expected, actual);
            }
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
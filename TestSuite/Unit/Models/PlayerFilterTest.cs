using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class PlayerFilterTest
    {
        private static readonly List<string> IDS = new List<string>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            IDS.Add("0");
            IDS.Add("1");
            IDS.Add("2");
        }
        
        [Theory]
        public void IdIn_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            var args = IDS.ToArray();
            var filter = new TestablePlayerFilter();

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

        [Test]
        public void IdIn_NoArguments_FieldIsEmpty()
        {
            // Arrange
            var filter = new TestablePlayerFilter();
            
            // Act
            filter.IdIn();
            var actual = filter.GetIdIn();

            // Assert
            Assert.NotNull(actual);
            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void IdIn_NullArgument_FieldIsNull()
        {
            // Arrange
            var filter = new TestablePlayerFilter();
            
            // Act
            filter.IdIn(null);
            var actual = filter.GetIdIn();

            // Assert
            Assert.Null(actual);
        }
        
        private class TestablePlayerFilter : PlayerFilter
        {
            private static readonly FieldInfo ID_IN_FIELD;

            static TestablePlayerFilter()
            {
                var type = typeof(PlayerFilter);
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
            }

            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
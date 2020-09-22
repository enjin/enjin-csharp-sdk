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
        
        [Test]
        public void Id_PassedArguments_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var filter = new TestablePlayerFilter();

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
            var filter = new TestablePlayerFilter();

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
        
        private class TestablePlayerFilter : PlayerFilter
        {
            private static readonly FieldInfo ID_FIELD;
            private static readonly FieldInfo ID_IN_FIELD;

            static TestablePlayerFilter()
            {
                var type = typeof(PlayerFilter);
                ID_FIELD = GetPrivateAttribute(type, "_id");
                ID_IN_FIELD = GetPrivateAttribute(type, "_idIn");
            }

            public string GetId() => ID_FIELD.GetValue(this) as string;

            public List<string> GetIdIn() => ID_IN_FIELD.GetValue(this) as List<string>;
        }
    }
}
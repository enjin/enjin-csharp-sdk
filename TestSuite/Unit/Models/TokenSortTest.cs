using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TokenSortTest
    {
        [Theory]
        public void Field_FieldContainsArgument(TokenField expected)
        {
            // Arrange
            var sort = new TestableTokenSort();
            
            // Act
            sort.Field(expected);
            var actual = sort.GetField();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Theory]
        public void Direction_FieldContainsArgument(SortDirection expected)
        {
            // Arrange
            var sort = new TestableTokenSort();
            
            // Act
            sort.Direction(expected);
            var actual = sort.GetDirection();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private class TestableTokenSort : TokenSort
        {
            private static readonly FieldInfo FIELD_FIELD;
            private static readonly FieldInfo DIRECTION_FIELD;

            static TestableTokenSort()
            {
                var type = typeof(TokenSort);
                FIELD_FIELD = GetPrivateAttribute(type, "_field");
                DIRECTION_FIELD = GetPrivateAttribute(type, "_direction");
            }

            public TokenField GetField() => (TokenField) FIELD_FIELD.GetValue(this);

            public SortDirection GetDirection() => (SortDirection) DIRECTION_FIELD.GetValue(this);
        }
    }
}
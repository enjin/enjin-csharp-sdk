using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TransactionSortTest
    {
        [Theory]
        public void Field_FieldContainsArgument(TransactionField expected)
        {
            // Arrange
            var sort = new TestableTransactionSort();

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
            var sort = new TestableTransactionSort();

            // Act
            sort.Direction(expected);
            var actual = sort.GetDirection();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private class TestableTransactionSort : TransactionSort
        {
            private static readonly FieldInfo FIELD_FIELD;
            private static readonly FieldInfo DIRECTION_FIELD;

            static TestableTransactionSort()
            {
                var type = typeof(TransactionSort);
                FIELD_FIELD = GetPrivateAttribute(type, "_field");
                DIRECTION_FIELD = GetPrivateAttribute(type, "_direction");
            }

            public TransactionField GetField() => (TransactionField) FIELD_FIELD.GetValue(this);
            
            public SortDirection GetDirection() => (SortDirection) DIRECTION_FIELD.GetValue(this);
        }
    }
}
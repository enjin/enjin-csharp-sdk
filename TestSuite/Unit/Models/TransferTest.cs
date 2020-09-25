using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TransferTest
    {
        [Test]
        public void From_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transfer = new TestableTransfer();

            // Act
            transfer.From(expected);
            var actual = transfer.GetFrom();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void To_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transfer = new TestableTransfer();

            // Act
            transfer.To(expected);
            var actual = transfer.GetTo();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenId_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transfer = new TestableTransfer();

            // Act
            transfer.TokenId(expected);
            var actual = transfer.GetTokenId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenIndex_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transfer = new TestableTransfer();

            // Act
            transfer.TokenIndex(expected);
            var actual = transfer.GetTokenIndex();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transfer = new TestableTransfer();

            // Act
            transfer.Value(expected);
            var actual = transfer.GetValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private class TestableTransfer : Transfer
        {
            private static readonly FieldInfo FROM_FIELD;
            private static readonly FieldInfo TO_FIELD;
            private static readonly FieldInfo TOKEN_ID_FIELD;
            private static readonly FieldInfo TOKEN_INDEX_FIELD;
            private static readonly FieldInfo VALUE_FIELD;

            static TestableTransfer()
            {
                var type = typeof(Transfer);
                FROM_FIELD = GetPrivateAttribute(type, "_from");
                TO_FIELD = GetPrivateAttribute(type, "_to");
                TOKEN_ID_FIELD = GetPrivateAttribute(type, "_tokenId");
                TOKEN_INDEX_FIELD = GetPrivateAttribute(type, "_tokenIndex");
                VALUE_FIELD = GetPrivateAttribute(type, "_value");
            }

            public string GetFrom() => FROM_FIELD.GetValue(this) as string;
            
            public string GetTo() => TO_FIELD.GetValue(this) as string;
            
            public string GetTokenId() => TOKEN_ID_FIELD.GetValue(this) as string;
            
            public string GetTokenIndex() => TOKEN_INDEX_FIELD.GetValue(this) as string;
            
            public string GetValue() => VALUE_FIELD.GetValue(this) as string;
        }
    }
}
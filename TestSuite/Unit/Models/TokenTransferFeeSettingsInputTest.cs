using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TokenTransferFeeSettingsInputTest
    {
        [Theory]
        public void Type_FieldContainsArgument(TokenTransferFeeType expected)
        {
            // Arrange
            var transferSettings = new TestableTokenTransferFeeSettingsInput();
            
            // Act
            transferSettings.Type(expected);
            var actual = transferSettings.GetType();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenId_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transferSettings = new TestableTokenTransferFeeSettingsInput();
            
            // Act
            transferSettings.TokenId(expected);
            var actual = transferSettings.GetTokenId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var transferSettings = new TestableTokenTransferFeeSettingsInput();
            
            // Act
            transferSettings.Value(expected);
            var actual = transferSettings.GetValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private class TestableTokenTransferFeeSettingsInput : TokenTransferFeeSettingsInput
        {
            private static readonly PropertyInfo TYPE_PROPERTY;
            private static readonly PropertyInfo TOKEN_ID_PROPERTY;
            private static readonly PropertyInfo VALUE_PROPERTY;

            static TestableTokenTransferFeeSettingsInput()
            {
                var type = typeof(TestableTokenTransferFeeSettingsInput);
                TYPE_PROPERTY = GetPublicProperty(type, "Type");
                TOKEN_ID_PROPERTY = GetPublicProperty(type, "TokenId");
                VALUE_PROPERTY = GetPublicProperty(type, "Value");
            }

            public new TokenTransferFeeType GetType() => (TokenTransferFeeType) TYPE_PROPERTY.GetValue(this);
            
            public string GetTokenId() => TOKEN_ID_PROPERTY.GetValue(this) as string;
            
            public string GetValue() => VALUE_PROPERTY.GetValue(this) as string;
        }
    }
}
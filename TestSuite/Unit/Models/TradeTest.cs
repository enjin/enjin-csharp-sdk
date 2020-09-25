using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TradeTest
    {
        [Test]
        public void TokenId_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var trade = new TestableTrade();

            // Act
            trade.TokenId(expected);
            var actual = trade.GetTokenId();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenIndex_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var trade = new TestableTrade();

            // Act
            trade.TokenIndex(expected);
            var actual = trade.GetTokenIndex();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var trade = new TestableTrade();

            // Act
            trade.Value(expected);
            var actual = trade.GetValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private class TestableTrade : Trade
        {
            private static readonly FieldInfo TOKEN_ID_FIELD;
            private static readonly FieldInfo TOKEN_INDEX_FIELD;
            private static readonly FieldInfo VALUE_FIELD;

            static TestableTrade()
            {
                var type = typeof(Trade);
                TOKEN_ID_FIELD = GetPrivateAttribute(type, "_tokenid");
                TOKEN_INDEX_FIELD = GetPrivateAttribute(type, "_tokenIndex");
                VALUE_FIELD = GetPrivateAttribute(type, "_value");
            }

            public string GetTokenId() => TOKEN_ID_FIELD.GetValue(this) as string;
            
            public string GetTokenIndex() => TOKEN_INDEX_FIELD.GetValue(this) as string;
            
            public string GetValue() => VALUE_FIELD.GetValue(this) as string;
        }
    }
}
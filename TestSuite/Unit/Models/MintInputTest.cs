using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class MintInputTest
    {
        [Test]
        public void To_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var mintInput = new TestableMintInput();

            // Act
            mintInput.To(expected);
            var actual = mintInput.GetTo();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_FieldContainsArgument()
        {
            // Arrange
            const string expected = "0";
            var mintInput = new TestableMintInput();

            // Act
            mintInput.Value(expected);
            var actual = mintInput.GetValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private class TestableMintInput : MintInput
        {
            private static readonly FieldInfo TO_FIELD;
            private static readonly FieldInfo VALUE_FIELD;

            static TestableMintInput()
            {
                var type = typeof(MintInput);
                TO_FIELD = GetPrivateAttribute(type, "_to");
                VALUE_FIELD = GetPrivateAttribute(type, "_value");
            }

            public string GetTo() => TO_FIELD.GetValue(this) as string;
            
            public string GetValue() => VALUE_FIELD.GetValue(this) as string;
        }
    }
}
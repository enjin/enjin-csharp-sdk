using Enjin.SDK.Utils;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void EqualsIgnoreCase_SameLetters_ReturnTrue([Values("aaa", "AAA", "aAa")] string string1,
                                                            [Values("aaa", "AAA", "aAa")] string string2)
        {
            // Act
            var result = string1.EqualsIgnoreCase(string2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsIgnoreCase_DifferentLetters_ReturnFalse([Values("aaa", "AAA", "aAa")] string string1,
                                                                  [Values("bbb", "BBB", "bBb")] string string2)
        {
            // Act
            var result = string1.EqualsIgnoreCase(string2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsIgnoreCase_OnlyDigits_ReturnTrue()
        {
            // Arrange
            const string string1 = "000";
            const string string2 = "000";
            
            // Act
            var result = string1.EqualsIgnoreCase(string2);

            // Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void EqualsIgnoreCase_OnlyDigits_ReturnFalse()
        {
            // Arrange
            const string string1 = "000";
            const string string2 = "111";
            
            // Act
            var result = string1.EqualsIgnoreCase(string2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
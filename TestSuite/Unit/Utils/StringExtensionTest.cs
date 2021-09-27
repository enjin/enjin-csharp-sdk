/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
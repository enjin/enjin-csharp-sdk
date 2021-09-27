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

using Enjin.SDK.Graphql;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TestSuite.Utils;

namespace TestSuite
{
    [TestFixture]
    public class GraphqlDataTest
    {
        private static readonly DummyObject DEFAULT_OBJECT = new DummyObject(1);

        [Test]
        public void Constructor_ObjectToken_DoesNotThrowException()
        {
            // Arrange
            var result = JToken.Parse(@"{}");
            
            // Assert
            Assert.DoesNotThrow(() => new GraphqlData<object>(result));
        }
        
        [Test]
        public void Constructor_NonObjectToken_DoesNotThrowException()
        {
            // Arrange
            var result = JToken.Parse(@"'primitive'");
            
            // Assert
            Assert.DoesNotThrow(() => new GraphqlData<object>(result));
        }
        
        [Test]
        public void Constructor_PaginatedToken_DoesNotThrowException()
        {
            // Arrange
            var result = JToken.Parse(@"{'items': [], 'cursor': {}}");
            
            // Assert
            Assert.DoesNotThrow(() => new GraphqlData<object>(result));
        }
        
        [Test]
        public void Result_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_OBJECT;
            var result = JObject.FromObject(expected);

            // Act
            var actual = new GraphqlData<DummyObject>(result).Result;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_ReturnsStringWithResult()
        {
            // Arrange
            var expected = $"Result: {DEFAULT_OBJECT}";
            var result = JObject.FromObject(DEFAULT_OBJECT);

            // Act
            var actual = new GraphqlData<DummyObject>(result).ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
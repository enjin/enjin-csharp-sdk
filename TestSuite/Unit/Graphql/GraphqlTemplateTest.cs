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

using System.Collections.Generic;
using Enjin.SDK.Graphql;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GraphqlTemplateTest
    {
        private const string DefaultEmptyLine = "";
        private const string DefaultNamespace = "enjin.graphql.Template";

        [Test]
        public void ReadNamespace_ContentsDoesHaveNamespace_ReturnsExpectedString()
        {
            // Arrange
            const string expected = DefaultNamespace;
            var contents = new List<string>
            {
                DefaultEmptyLine,
                $"{GraphqlTemplate.NAMESPACE_KEY} {expected}",
                DefaultEmptyLine,
            };

            // Act
            var actual = GraphqlTemplate.ReadNamespace(contents);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ReadNamespace_ContentsDoesNotHaveNamespace_ReturnsNull()
        {
            // Arrange
            var contents = new List<string>
            {
                DefaultEmptyLine,
                DefaultEmptyLine,
                DefaultEmptyLine,
            };

            // Act
            var actual = GraphqlTemplate.ReadNamespace(contents);

            // Assert
            Assert.IsNull(actual);
        }
    }
}
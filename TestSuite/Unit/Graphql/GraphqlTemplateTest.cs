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
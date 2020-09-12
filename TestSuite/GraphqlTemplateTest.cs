using System.Collections.Generic;
using Enjin.SDK.Graphql;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GraphqlTemplateTest
    {
        [Test]
        [TestCase("enjin.graphql.Template")]
        public void ReadNamespace_ContentsDoesHaveNamespace_ReturnsTheNamespace(string expected)
        {
            // Arrange
            var contents = new List<string>
            {
                "dummy line",
                $"{GraphqlTemplate.NAMESPACE_KEY} {expected}",
                "dummy line",
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
                "dummy line",
                "dummy line",
                "dummy line",
            };

            // Act
            var actual = GraphqlTemplate.ReadNamespace(contents);

            // Assert
            Assert.IsNull(actual);
        }
    }
}
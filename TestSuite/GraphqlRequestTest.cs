using Enjin.SDK.Graphql;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GraphqlRequestTest
    {
        [Test]
        [TestCase(1)]
        [TestCase(1.0)]
        [TestCase(1.0f)]
        [TestCase(1L)]
        [TestCase('1')]
        [TestCase("1")]
        [TestCase(true)]
        public void SetVariable_MultipleTypes_RequestContainsVariable(object v)
        {
            // Arrange
            const string k = "variable";
            var request = new TestableGraphqlRequest();

            // Act
            request.SetVariable(k, v);

            // Assert
            Assert.AreSame(v, request.Variables[k]);
        }

        [Test]
        public void IsSet_ReturnTrue()
        {
            // Arrange
            const string k = "variable";
            const int v = 0;
            var request = new TestableGraphqlRequest();

            // Act
            request.SetVariable(k, v);

            // Assert
            Assert.IsTrue(request.IsSet(k));
        }

        [Test]
        public void IsSet_ReturnFalse()
        {
            // Arrange
            const string k = "variable";
            var request = new TestableGraphqlRequest();

            // Assert
            Assert.IsFalse(request.IsSet(k));
        }

        private class TestableGraphqlRequest : GraphqlRequest<TestableGraphqlRequest>
        {
            public TestableGraphqlRequest() : base("")
            {
            }
        }
    }
}
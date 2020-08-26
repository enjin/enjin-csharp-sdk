using Enjin.SDK;
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class BaseSchemaTest
    {
        [Test]
        public void CreateRequestBody_ReturnHasQueryAndVariableAttributes()
        {
            // Arrange
            const string queryKey = "query";
            const string variablesKey = "variables";
            var schema = new TestableBaseSchema();
            var request = new GetProject()
                .Id(1234);

            // Act
            var body = schema.CreateRequestBody(request);

            // Assert
            Assert.NotNull(body[queryKey]);
            Assert.NotNull(body[variablesKey]);
        }

        private class TestableBaseSchema : BaseSchema
        {
            private static readonly TrustedPlatformMiddleware MIDDLEWARE =
                new TrustedPlatformMiddleware(EnjinHosts.KOVAN, false);

            public TestableBaseSchema() : base(MIDDLEWARE, "")
            {
            }

            public new JToken CreateRequestBody(IGraphqlRequest request) => base.CreateRequestBody(request);
        }
    }
}
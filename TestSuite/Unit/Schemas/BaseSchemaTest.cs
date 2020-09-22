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
            var request = CreateValidRequest();

            // Act
            var body = schema.CreateRequestBody(request);

            // Assert
            Assert.NotNull(body[queryKey]);
            Assert.NotNull(body[variablesKey]);
        }
        
        [Test]
        public void CreateService_IBalanceService_CreatesTheService()
        {
            // Arrange
            var schema = new TestableBaseSchema();
            
            // Act
            var actual = schema.CreateService<IBalanceService>();
            
            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IPlatformService_CreatesTheService()
        {
            // Arrange
            var schema = new TestableBaseSchema();
            
            // Act
            var actual = schema.CreateService<IPlatformService>();
            
            // Assert
            Assert.NotNull(actual);
        }
        
        [Test]
        public void CreateService_IPlayerService_CreatesTheService()
        {
            // Arrange
            var schema = new TestableBaseSchema();
            
            // Act
            var actual = schema.CreateService<IPlayerService>();
            
            // Assert
            Assert.NotNull(actual);
        }
        
        [Test]
        public void CreateService_IProjectService_CreatesTheService()
        {
            // Arrange
            var schema = new TestableBaseSchema();
            
            // Act
            var actual = schema.CreateService<IProjectService>();
            
            // Assert
            Assert.NotNull(actual);
        }
        
        [Test]
        public void CreateService_IRequestService_CreatesTheService()
        {
            // Arrange
            var schema = new TestableBaseSchema();
            
            // Act
            var actual = schema.CreateService<IRequestService>();
            
            // Assert
            Assert.NotNull(actual);
        }
        
        [Test]
        public void CreateService_ITokenService_CreatesTheService()
        {
            // Arrange
            var schema = new TestableBaseSchema();
            
            // Act
            var actual = schema.CreateService<ITokenService>();
            
            // Assert
            Assert.NotNull(actual);
        }

        private static IGraphqlRequest CreateValidRequest() => new GetPlatform();

        private class TestableBaseSchema : BaseSchema
        {
            private static readonly TrustedPlatformMiddleware MIDDLEWARE =
                new TrustedPlatformMiddleware(EnjinHosts.KOVAN, false);

            public TestableBaseSchema() : base(MIDDLEWARE, "")
            {
            }

            public new JToken CreateRequestBody(IGraphqlRequest request) => base.CreateRequestBody(request);

            public new T CreateService<T>() => base.CreateService<T>();
        }
    }
}
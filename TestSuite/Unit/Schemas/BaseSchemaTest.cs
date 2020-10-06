using System;
using System.Net;
using System.Threading.Tasks;
using Enjin.SDK;
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Refit;
using TestSuite.Utils;
using WireMock.Server;
using WireMock.Settings;

namespace TestSuite
{
    [TestFixture]
    public class BaseSchemaTest
    {
        private static WireMockServer _server;

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            _server = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = new[] {"https://localhost/"},
            });
        }

        [SetUp]
        public static void BeforeEach()
        {
            _server.Reset();
        }

        [OneTimeTearDown]
        public static void AfterAll()
        {
            _server.Stop();
        }

        [Test]
        public void CreateRequestBody_ReturnHasQueryAndVariableAttributes()
        {
            // Arrange
            const string queryKey = "query";
            const string variablesKey = "variables";
            var schema = CreateDefaultTestableBaseSchemaSchema();
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
            var schema = CreateDefaultTestableBaseSchemaSchema();

            // Act
            var actual = schema.CreateService<IBalanceService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IPlatformService_CreatesTheService()
        {
            // Arrange
            var schema = CreateDefaultTestableBaseSchemaSchema();

            // Act
            var actual = schema.CreateService<IPlatformService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IPlayerService_CreatesTheService()
        {
            // Arrange
            var schema = CreateDefaultTestableBaseSchemaSchema();

            // Act
            var actual = schema.CreateService<IPlayerService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IProjectService_CreatesTheService()
        {
            // Arrange
            var schema = CreateDefaultTestableBaseSchemaSchema();

            // Act
            var actual = schema.CreateService<IProjectService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IRequestService_CreatesTheService()
        {
            // Arrange
            var schema = CreateDefaultTestableBaseSchemaSchema();

            // Act
            var actual = schema.CreateService<IRequestService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_ITokenService_CreatesTheService()
        {
            // Arrange
            var schema = CreateDefaultTestableBaseSchemaSchema();

            // Act
            var actual = schema.CreateService<ITokenService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public async Task SendRequest_SuccessfulResponse_ReturnsResponseWithContent()
        {
            // Arrange - Data
            var expected = new DummyObject(1);
            var responseBody = $"{{\"data\": {JObject.FromObject(expected)}}}";
            var schema = CreateDefaultTestableBaseSchemaSchema();
            var service = schema.CreateService<IFakeService>();
            var taskIn = service.Post(schema.Schema, JObject.Parse(@"{}"));
            _server.Given(WireMock.RequestBuilders.Request.Create()
                                  .WithPath($"/graphql/{schema.Schema}")
                                  .UsingPost())
                   .RespondWith(WireMock.ResponseBuilders.Response.Create()
                                        .WithStatusCode(HttpStatusCode.OK)
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Act
            var response = await TestableBaseSchema.SendRequest(taskIn);
            var actual = response.Result;

            // Assert
            Assert.IsFalse(response.HasErrors());
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task SendRequest_FailedResponse_ReturnsResponseWithErrors()
        {
            // Arrange
            const string responseBody = @"{""errors"":[{""message"":""generic error""}]}";
            var schema = CreateDefaultTestableBaseSchemaSchema();
            var service = schema.CreateService<IFakeService>();
            var taskIn = service.Post(schema.Schema, JObject.Parse(@"{}"));
            _server.Given(WireMock.RequestBuilders.Request.Create()
                                  .WithPath($"/graphql/{schema.Schema}")
                                  .UsingPost())
                   .RespondWith(WireMock.ResponseBuilders.Response.Create()
                                        .WithStatusCode(HttpStatusCode.BadRequest)
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Act
            var response = await TestableBaseSchema.SendRequest(taskIn);
            var actual = response.Result;

            // Assert
            Assert.IsTrue(response.HasErrors());
            Assert.IsNull(actual);
        }

        private static IGraphqlRequest CreateValidRequest() => new GetPlatform();

        private static TestableBaseSchema CreateDefaultTestableBaseSchemaSchema() =>
            new TestableBaseSchema(_server.Urls[0]);

        [Headers("Content-Type: application/json")]
        internal interface IFakeService
        {
            [Post("/graphql/{schema}")]
            Task<ApiResponse<GraphqlResponse<DummyObject>>> Post(string schema,
                                                                 [Body(BodySerializationMethod.Serialized)]
                                                                 JObject body);
        }

        private class TestableBaseSchema : BaseSchema
        {
            public new string Schema => base.Schema;

            public TestableBaseSchema(string uri) : base(new TrustedPlatformMiddleware(new Uri(uri), false), "")
            {
            }

            public new JToken CreateRequestBody(IGraphqlRequest request) => base.CreateRequestBody(request);

            public new T CreateService<T>() => base.CreateService<T>();

            public new static Task<GraphqlResponse<T>> SendRequest<T>(Task<ApiResponse<GraphqlResponse<T>>> taskIn) =>
                BaseSchema.SendRequest(taskIn);
        }
    }
}
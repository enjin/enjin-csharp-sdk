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

        private TestableBaseSchema ClassUnderTest { get; set; }

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            _server = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = new[] {"https://localhost/"},
            });
        }

        [SetUp]
        public void BeforeEach()
        {
            _server.Reset();
            ClassUnderTest = new TestableBaseSchema(new TrustedPlatformMiddleware(new Uri(_server.Urls[0]), false),
                                                    "test");
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
            var request = CreateValidRequest();

            // Act
            var body = ClassUnderTest.CreateRequestBody(request);

            // Assert
            Assert.NotNull(body[queryKey]);
            Assert.NotNull(body[variablesKey]);
        }

        [Test]
        public void CreateService_IBalanceService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<IBalanceService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IPlatformService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<IPlatformService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IPlayerService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<IPlayerService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IProjectService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<IProjectService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IRequestService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<IRequestService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_ITokenService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<ITokenService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateService_IWalletService_CreatesTheService()
        {
            // Act
            var actual = ClassUnderTest.CreateService<IWalletService>();

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public async Task SendRequest_SuccessfulResponse_ReturnsResponseWithContent()
        {
            // Arrange
            var expected = new DummyObject(1);
            var responseBody = $"{{\"data\": {{\"result\": {JObject.FromObject(expected)}}}}}";
            var service = ClassUnderTest.CreateService<IFakeService>();
            var taskIn = service.Post(ClassUnderTest.Schema, JObject.Parse(@"{}"));
            _server.Given(WireMock.RequestBuilders.Request.Create()
                                  .WithPath($"/graphql/{ClassUnderTest.Schema}")
                                  .UsingPost())
                   .RespondWith(WireMock.ResponseBuilders.Response.Create()
                                        .WithStatusCode(HttpStatusCode.OK)
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Act
            var response = await TestableBaseSchema.SendRequest(taskIn);
            var actual = response.Result;

            // Assert
            Assert.IsFalse(response.HasErrors);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task SendRequest_FailedResponse_ReturnsResponseWithErrors()
        {
            // Arrange
            const string responseBody = @"{""errors"":[{""message"":""generic error""}]}";
            var service = ClassUnderTest.CreateService<IFakeService>();
            var taskIn = service.Post(ClassUnderTest.Schema, JObject.Parse(@"{}"));
            _server.Given(WireMock.RequestBuilders.Request.Create()
                                  .WithPath($"/graphql/{ClassUnderTest.Schema}")
                                  .UsingPost())
                   .RespondWith(WireMock.ResponseBuilders.Response.Create()
                                        .WithStatusCode(HttpStatusCode.BadRequest)
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Act
            var response = await TestableBaseSchema.SendRequest(taskIn);

            // Assert
            Assert.IsTrue(response.HasErrors);
        }

        private static IGraphqlRequest CreateValidRequest() => new GetPlatform();

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

            public TestableBaseSchema(TrustedPlatformMiddleware middleware, string schema) : base(middleware, schema)
            {
            }

            public new JToken CreateRequestBody(IGraphqlRequest request) => base.CreateRequestBody(request);

            public new T CreateService<T>() => base.CreateService<T>();

            public new static Task<GraphqlResponse<T>> SendRequest<T>(Task<ApiResponse<GraphqlResponse<T>>> taskIn) =>
                BaseSchema.SendRequest(taskIn);
        }
    }
}
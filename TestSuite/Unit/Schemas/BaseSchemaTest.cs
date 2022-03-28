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

using System;
using System.Net;
using System.Threading.Tasks;
using Enjin.SDK;
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using Enjin.SDK.Utils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TestSuite.Utils;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
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
                Urls = new[] { "http://localhost/" },
            });
        }

        [SetUp]
        public void BeforeEach()
        {
            _server.Reset();

            var middleware = new TrustedPlatformMiddleware(new Uri(_server.Urls[0]));
            ClassUnderTest = new TestableBaseSchema(middleware, "test");
        }

        [OneTimeTearDown]
        public static void AfterAll()
        {
            _server.Stop();
            _server.Dispose();
        }

        [Test]
        [Timeout(5000)]
        public void SendRequest_SuccessfulResponse_ReturnsResponseWithContent()
        {
            // Arrange - Data
            var expected = new DummyObject(1);
            var responseBody = $"{{\"data\": {{\"result\": {JObject.FromObject(expected)}}}}}";
            var dummyRequest = CreateValidRequest();

            // Arrange - Stubbing
            _server.Given(Request.Create()
                                 .WithPath($"/graphql/{ClassUnderTest.Schema}")
                                 .UsingPost())
                   .RespondWith(Response.Create()
                                        .WithSuccess()
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Act
            var response = ClassUnderTest.SendRequest<DummyObject>(dummyRequest).Result;

            // Assert
            Assert.IsFalse(response.HasErrors, "The response has errors.");
            Assert.AreEqual(expected, response.Result, "The response does not have the expected data.");
        }

        [Test]
        [Timeout(5000)]
        public void SendRequest_FailedResponse_ReturnsResponseWithErrors()
        {
            // Arrange - Data
            const string responseBody = @"{""errors"":[{""message"":""generic error""}]}";
            var dummyRequest = CreateValidRequest();

            // Arrange - Stubbing
            _server.Given(Request.Create()
                                 .WithPath($"/graphql/{ClassUnderTest.Schema}")
                                 .UsingPost())
                   .RespondWith(Response.Create()
                                        .WithStatusCode(HttpStatusCode.BadRequest)
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Act
            var response = ClassUnderTest.SendRequest<DummyObject>(dummyRequest).Result;

            // Assert
            Assert.IsTrue(response.HasErrors);
        }

        private static IGraphqlRequest CreateValidRequest() => new GetPlatform();

        private class TestableBaseSchema : BaseSchema
        {
            public new string Schema => base.Schema;

            public TestableBaseSchema(TrustedPlatformMiddleware middleware, string schema) : base(middleware, schema,
                LoggerProvider.CreateDefaultLoggerProvider())
            {
            }

            public new Task<GraphqlResponse<T>> SendRequest<T>(IGraphqlRequest request) => base.SendRequest<T>(request);
        }
    }
}
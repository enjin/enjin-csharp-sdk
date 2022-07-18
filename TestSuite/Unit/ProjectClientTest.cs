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
using System.Linq;
using System.Threading;
using Enjin.SDK;
using Enjin.SDK.Models;
using JetBrains.Annotations;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using Request = WireMock.RequestBuilders.Request;

namespace TestSuite
{
    [TestFixture]
    public class ProjectClientTest
    {
        private static WireMockServer _server;

        private ProjectClient ClassUnderTest { get; set; }

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
            ClassUnderTest = ProjectClient.Builder()
                                          .BaseUri(new Uri(_server.Urls[0]))
                                          .Build();
        }

        [OneTimeTearDown]
        public static void AfterAll()
        {
            _server.Stop();
            _server.Dispose();
        }

        [TearDown]
        public void AfterEach()
        {
            ClassUnderTest.Dispose();
        }

        [Test]
        public void IsAuthenticated_AuthenticatedWithValidToken_ReturnsTrue()
        {
            // Arrange
            const string fakeToken = "xyz";
            ClassUnderTest.Auth(fakeToken);

            // Act
            var actual = ClassUnderTest.IsAuthenticated;

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsAuthenticated_AuthenticatedWithInvalidToken_ReturnsFalse([Values("", " ", null)] string fakeToken)
        {
            // Arrange
            ClassUnderTest.Auth(fakeToken);

            // Act
            var actual = ClassUnderTest.IsAuthenticated;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void IsClosed_ClientHasBeenDisposed_ReturnsTrue()
        {
            // Arrange
            ClassUnderTest.Dispose();

            // Act
            var actual = ClassUnderTest.IsClosed;

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsClosed_ClientHasNotBeenDisposed_ReturnsFalse()
        {
            // Act
            var actual = ClassUnderTest.IsClosed;

            // Assert
            Assert.IsFalse(actual);
        }
    }

    [TestFixture]
    public class ProjectClientReauthenticateTest
    {
        private const string FakeUuid = "Fake Uuid";
        private const string FakeSecret = "Fake Secret";

        private static WireMockServer _server;

        private ProjectClient ClassUnderTest { get; set; }

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
            ClassUnderTest = ProjectClient.Builder()
                                          .BaseUri(new Uri(_server.Urls[0]))
                                          .EnableAutomaticReauthentication()
                                          .Build();
        }

        [OneTimeTearDown]
        public static void AfterAll()
        {
            _server.Stop();
            _server.Dispose();
        }

        [TearDown]
        public void AfterEach()
        {
            ClassUnderTest.Dispose();
        }

        [Test]
        public void Auth_GivenAccessTokenWhileClientHasNullUuidAndSecret_DoesNotStartReauthenticationTimer()
        {
            // Arrange
            AccessToken fakeToken = CreateFakeAccessToken("xyz", 1000);

            // Assumption
            Assume.That(ClassUnderTest.IsAutomaticReauthenticationEnabled, "Automatic reauthentication is disabled.");
            Assume.That(ClassUnderTest.IsReauthenticationRunning == false,
                        "Timer is running before call to authenticate.");

            // Act
            ClassUnderTest.Auth(fakeToken);

            // Assert
            Assert.IsFalse(ClassUnderTest.IsReauthenticationRunning, "Reauthentication still is running.");
        }

        [Test]
        [Timeout(5000)]
        public void AuthProject_GiveValidUuidAndSecret_ClientReauthenticates()
        {
            // Arrange - Data
            const string authToken = "FakeAuthToken";
            const string expectedPath = "/graphql/project";
            const string expectedHeader = HeaderNames.Authorization;
            string expectedHeaderValue = $"Bearer {authToken}";
            IRequestBuilder requestBuilder = Request.Create().WithPath(expectedPath).UsingPost();
            AccessToken fakeToken = CreateFakeAccessToken(authToken, 1);
            string responseBody = $"{{\"data\":{{\"result\":{JObject.FromObject(fakeToken)}}}}}";

            // Arrange - Mocking
            _server.Given(requestBuilder)
                   .RespondWith(Response.Create()
                                        .WithSuccess()
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Assumption
            Assume.That(ClassUnderTest.IsAutomaticReauthenticationEnabled, "Automatic reauthentication is disabled.");
            Assume.That(ClassUnderTest.IsAuthenticated == false, "Is authenticated before request is sent.");

            // Act
            var task = ClassUnderTest.AuthClient(FakeUuid, FakeSecret);

            task.Wait();
            Thread.Sleep(2000);

            // Assert
            Assert.IsFalse(task.IsFaulted, "AuthClient operation faulted.");
            Assert.IsTrue(ClassUnderTest.IsAuthenticated, "Client was not authenticated.");

            // Verify
            var logEntries = _server.FindLogEntries(requestBuilder).ToArray();
            Assert.Greater(logEntries.Length, 1, "Did not receive more than one request.");

            var req1 = logEntries[0].RequestMessage;
            Assert.AreEqual(expectedPath, req1.Path, "Req1 is not to the expected path.");
            Assert.IsFalse(req1.Headers.ContainsKey(expectedHeader), "Req1 had authorization.");

            var req2 = logEntries[1].RequestMessage;
            Assert.AreEqual(expectedPath, req2.Path, "Req2 is not to the expected path.");
            Assert.AreEqual(expectedHeaderValue, req2.Headers[expectedHeader][0], "Req2 did not have authorization.");
        }

        [Test]
        [Timeout(5000)]
        public void Auth_GivenNullToken_ReauthenticationStoppedInvoked()
        {
            // Arrange - Data
            bool verificationFlag = false;
            AccessToken fakeToken = CreateFakeAccessToken("xyz", 1000);
            string responseBody = $"{{\"data\":{{\"result\":{JObject.FromObject(fakeToken)}}}}}";

            // Arrange - Stubbing
            _server.Given(Request.Create()
                                 .WithPath("/graphql/project")
                                 .UsingPost())
                   .RespondWith(Response.Create()
                                        .WithSuccess()
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Arrange - Data (continued)
            ClassUnderTest.OnAutomaticReauthenticationStopped += (sender, args) => verificationFlag = true;
            ClassUnderTest.AuthClient(FakeUuid, FakeSecret).Wait();

            // Assumption
            Assume.That(ClassUnderTest.IsAuthenticated, "Is not authenticated.");
            Assume.That(ClassUnderTest.IsReauthenticationRunning, "Reauthentication is not running.");

            // Act
            ClassUnderTest.Auth((AccessToken)null);

            // Assert
            Assert.IsFalse(ClassUnderTest.IsReauthenticationRunning, "Reauthentication is still running.");

            // Verify
            Assert.IsTrue(verificationFlag, "Flag was not set to true by timer stopped event.");
        }

        [Test]
        [Timeout(5000)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Auth_GivenTokenWithNonPositiveDuration_ReauthenticationStoppedInvoked(long expiresIn)
        {
            // Arrange - Data
            bool verificationFlag = false;
            AccessToken badToken = CreateFakeAccessToken("xyz", expiresIn);
            AccessToken fakeToken = CreateFakeAccessToken("xyz", 1000);
            string responseBody = $"{{\"data\":{{\"result\":{JObject.FromObject(fakeToken)}}}}}";

            // Arrange - Stubbing
            _server.Given(Request.Create()
                                 .WithPath("/graphql/project")
                                 .UsingPost())
                   .RespondWith(Response.Create()
                                        .WithSuccess()
                                        .WithHeader("Content-Type", "application/json")
                                        .WithBody(responseBody));

            // Arrange - Data (continued)
            ClassUnderTest.OnAutomaticReauthenticationStopped += (sender, args) => verificationFlag = true;
            ClassUnderTest.AuthClient(FakeUuid, FakeSecret).Wait();

            // Assumption
            Assume.That(ClassUnderTest.IsAuthenticated, "Is not authenticated.");
            Assume.That(ClassUnderTest.IsReauthenticationRunning, "Reauthentication is not running.");

            // Act
            ClassUnderTest.Auth(badToken);

            // Assert
            Assert.IsFalse(ClassUnderTest.IsReauthenticationRunning, "Reauthentication is still running.");

            // Verify
            Assert.IsTrue(verificationFlag, "Flag was not set to true by timer stopped event.");
        }

        private static AccessToken CreateFakeAccessToken([CanBeNull] string accessToken = null, long? expiresIn = null)
        {
            var obj = JObject.FromObject(new { accessToken, expiresIn });
            return JsonConvert.DeserializeObject<AccessToken>(obj.ToString());
        }
    }
}
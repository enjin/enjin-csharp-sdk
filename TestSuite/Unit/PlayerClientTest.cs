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
using Enjin.SDK;
using NUnit.Framework;
using WireMock.Server;
using WireMock.Settings;

namespace TestSuite
{
    [TestFixture]
    public class PlayerClientTest
    {
        private static WireMockServer _server;

        private PlayerClient ClassUnderTest { get; set; }

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
            ClassUnderTest = new PlayerClient(new Uri(_server.Urls[0]));
        }

        [OneTimeTearDown]
        public static void AfterAll()
        {
            _server.Stop();
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
}
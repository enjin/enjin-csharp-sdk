using System;
using Enjin.SDK;
using NUnit.Framework;
using WireMock.Server;
using WireMock.Settings;

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
                Urls = new[] {"https://localhost/"},
            });
        }

        [SetUp]
        public void BeforeEach()
        {
            _server.Reset();
            ClassUnderTest = new ProjectClient(new Uri(_server.Urls[0]));
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
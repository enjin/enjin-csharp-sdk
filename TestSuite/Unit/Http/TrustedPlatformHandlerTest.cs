using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Enjin.SDK.Http;
using Moq;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TrustedPlatformHandlerTest
    {
        private HttpMessageHandler MockMessageHandler { get; set; }
        private TestableTrustedPlatformHandler ClassUnderTest { get; set; }

        [SetUp]
        public void BeforeEach()
        {
            MockMessageHandler = Mock.Of<HttpMessageHandler>();
            ClassUnderTest = new TestableTrustedPlatformHandler(MockMessageHandler);
        }

        [Test]
        public void SendAsync_ValidAuthToken_AuthorizationIsSet()
        {
            // Arrange
            const string expectedSchema = "Bearer";
            const string expectedToken = "xyz";
            var dummyCancellationToken = new CancellationToken();
            var request = new HttpRequestMessage();
            ClassUnderTest.AuthToken = expectedToken;

            // Act
            ClassUnderTest.SendAsync(request, dummyCancellationToken);

            // Assert
            Assert.AreEqual(expectedSchema, request.Headers.Authorization.Scheme);
            Assert.AreEqual(expectedToken, request.Headers.Authorization.Parameter);
        }
        
        [Test]
        public void SendAsync_AuthTokenIsNullOrWhiteSpace_AuthorizationIsNotSet([Values("", "   ", null)] string token)
        {
            // Arrange
            var dummyCancellationToken = new CancellationToken();
            var request = new HttpRequestMessage();
            ClassUnderTest.AuthToken = token;

            Assume.That(request.Headers.Authorization, Is.Null);
            
            // Act
            ClassUnderTest.SendAsync(request, dummyCancellationToken);

            // Assert
            Assert.IsNull(request.Headers.Authorization);
        }

        private class TestableTrustedPlatformHandler : TrustedPlatformHandler
        {
            public TestableTrustedPlatformHandler(HttpMessageHandler innerHandler) : base(innerHandler)
            {
            }

            public new Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                           CancellationToken cancellationToken) =>
                base.SendAsync(request, cancellationToken);
        }
    }
}
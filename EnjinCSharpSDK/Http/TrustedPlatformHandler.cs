using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Enjin.SDK.Http
{
    /// <summary>
    /// Handler used by the HTTP client.
    /// </summary>
    public class TrustedPlatformHandler : DelegatingHandler
    {
        private string? _authToken;

        /// <summary>
        /// Constructs the handler with an optional inner handler.
        /// </summary>
        /// <param name="innerHandler">The handler to replace the default client handler.</param>
        public TrustedPlatformHandler(HttpMessageHandler innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler())
        {
        }

        /// <summary>
        /// Represents the authentication token for the SDK.
        /// </summary>
        /// <value>The auth token.</value>
        public string? AuthToken
        {
            set => _authToken = value;
        }

        /// <summary>
        /// Represents if the SDK is authenticated.
        /// </summary>
        /// <value>Whether the SDK is authenticated.</value>
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(_authToken);

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            if (IsAuthenticated)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
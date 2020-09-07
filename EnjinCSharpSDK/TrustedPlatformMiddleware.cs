using System;
using System.Net.Http;
using Enjin.SDK.Graphql;
using Enjin.SDK.Http;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Middleware for communicating with the Trusted Platform.
    /// </summary>
    /// <seealso cref="PlayerClient"/>
    /// <seealso cref="ProjectClient"/>
    [PublicAPI]
    public class TrustedPlatformMiddleware
    {
        /// <summary>
        /// The handler for communication with the Trusted Platform.
        /// </summary>
        public readonly TrustedPlatformHandler HttpHandler;
        
        /// <summary>
        /// The client for sending requests and receiving responses.
        /// </summary>
        public readonly HttpClient HttpClient;
        
        /// <summary>
        /// The query registry being used.
        /// </summary>
        public readonly GraphqlQueryRegistry Registry;

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="baseAddress">The base URI.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        /// <param name="handler">Prefered HTTP handler.</param>
        public TrustedPlatformMiddleware(Uri baseAddress, bool debug, HttpClientHandler handler = null)
        {
            HttpHandler = new TrustedPlatformHandler(handler);
            HttpClient = CreateHttpClient(baseAddress, debug);
            Registry = new GraphqlQueryRegistry();
        }

        private HttpClient CreateHttpClient(Uri baseAddress, bool debug)
        {
            var client = new HttpClient(debug ? (HttpMessageHandler) new HttpLoggingHandler(HttpHandler) : HttpHandler)
            {
                BaseAddress = baseAddress
            };

            client.DefaultRequestHeaders.UserAgent
                .TryParseAdd($"Enjin C# SDK v{typeof(TrustedPlatformMiddleware).Assembly.GetName().Version}");

            return client;
        }
    }
}
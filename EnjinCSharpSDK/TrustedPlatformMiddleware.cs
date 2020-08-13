using System;
using System.Net.Http;
using System.Reflection;
using Enjin.SDK.Graphql;
using Enjin.SDK.Http;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class TrustedPlatformMiddleware
    {
        public readonly TrustedPlatformHandler HttpHandler;
        public readonly HttpClient HttpClient;
        public readonly GraphqlQueryRegistry Registry;
        public readonly string Schema;

        public TrustedPlatformMiddleware(Uri baseAddress, bool debug, string schema, HttpClientHandler handler = null)
        {
            HttpHandler = new TrustedPlatformHandler(handler);
            HttpClient = CreateHttpClient(baseAddress, debug);
            Registry = new GraphqlQueryRegistry();
            Schema = schema;
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
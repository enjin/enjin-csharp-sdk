using System;
using System.Net.Http;
using System.Reflection;
using EnjinSDK.Graphql;
using EnjinSDK.Http;
using JetBrains.Annotations;

namespace EnjinSDK
{
    [PublicAPI]
    public class TrustedPlatformMiddleware
    {
        public readonly TrustedPlatformHandler HttpHandler;
        public readonly HttpClient HttpClient;
        public readonly GraphqlQueryRegistry Registry;

        public TrustedPlatformMiddleware(Uri baseAddress, bool debug)
        {
            HttpHandler = new TrustedPlatformHandler();
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
                .TryParseAdd($"Enjin C# SDK v{Assembly.GetExecutingAssembly().GetName().Version}");

            return client;
        }
    }
}
using System;
using System.Net.Http;
using System.Reflection;
using EnjinSDK.Graphql;
using EnjinSDK.Http;

namespace EnjinSDK
{
    public class TrustedPlatformMiddleware
    {
        public readonly TrustedPlatformHandler HttpHandler;
        public readonly HttpClient HttpClient;
        public readonly GraphqlQueryRegistry Registry;

        public TrustedPlatformMiddleware(Uri baseAddress)
        {
            HttpHandler = new TrustedPlatformHandler();
            HttpClient = CreateHttpClient(baseAddress);
            Registry = new GraphqlQueryRegistry();
        }

        private HttpClient CreateHttpClient(Uri baseAddress)
        {
            var client = new HttpClient(HttpHandler)
            {
                BaseAddress = baseAddress
            };

            client.DefaultRequestHeaders.UserAgent
                .TryParseAdd($"Enjin C# SDK v{Assembly.GetExecutingAssembly().GetName().Version}");

            return client;
        }
    }
}
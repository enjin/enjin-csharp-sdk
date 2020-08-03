using System;
using Enjin.SDK;
using Enjin.SDK.ProjectSchema;
using NUnit.Framework;
using Refit;

namespace TestSuite
{
    public class Tests
    {
        private ProjectClient _client;
        
        [SetUp]
        public void Setup()
        {
            _client = new TrustedPlatformClient(TrustedPlatformClient.KovanUrl);
        }

        [Test]
        public async Task Test1()
        {
            ApiResponse<GraphqlResponse<AccessToken>> response = await _client.AppService.AuthApp(new AuthApp().Id(2537)
                .Secret("xyz"));
            Console.Out.WriteLine(response.Content);
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            new TrustedPlatformMiddleware(TrustedPlatformClient.KovanUrl);
            Assert.Pass();
        }
    }
}
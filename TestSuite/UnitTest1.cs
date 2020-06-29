using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EnjinSDK;
using EnjinSDK.Graphql;
using EnjinSDK.Models;
using EnjinSDK.Models.App;
using NUnit.Framework;
using Refit;

namespace TestSuite
{
    public class Tests
    {
        private ITrustedPlatformClient _client;
        
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
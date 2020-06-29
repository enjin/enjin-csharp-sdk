using System;
using EnjinSDK.Services.App;
using JetBrains.Annotations;

namespace EnjinSDK
{
    [PublicAPI]
    public class TrustedPlatformClient : ITrustedPlatformClient
    {
        public static readonly Uri KovanUrl = new Uri("https://kovan.cloud.enjin.io/");
        public static readonly Uri MainNetUrl = new Uri("https://cloud.enjin.io/");

        public TrustedPlatformMiddleware Middleware { get; }
        public IAppService AppService { get; }
        
        public TrustedPlatformClient(Uri baseUri, bool debug)
        {
            Middleware = new TrustedPlatformMiddleware(baseUri, debug);
            AppService = new AppService(Middleware);
        }
    }
}
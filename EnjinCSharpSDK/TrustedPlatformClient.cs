using System;
using System.Collections.Generic;
using System.Net.Http;
using EnjinSDK.Services.App;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace EnjinSDK
{
    public class TrustedPlatformClient : ITrustedPlatformClient
    {
        public static readonly Uri KovanUrl = new Uri("https://kovan.cloud.enjin.io/");
        public static readonly Uri MainNetUrl = new Uri("https://cloud.enjin.io/");

        public TrustedPlatformMiddleware Middleware { get; }
        public IAppService AppService { get; }
        
        public TrustedPlatformClient(Uri baseUri)
        {
            Middleware = new TrustedPlatformMiddleware(baseUri);
            AppService = new AppService(Middleware);
        }
    }
}
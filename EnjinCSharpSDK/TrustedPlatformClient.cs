using System;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public abstract class TrustedPlatformClient : ITrustedPlatformClient
    {
        public static readonly Uri KovanUrl = new Uri("https://kovan.cloud.enjin.io/");
        public static readonly Uri MainNetUrl = new Uri("https://cloud.enjin.io/");
        
        public TrustedPlatformMiddleware Middleware { get; }
        public ISharedSchema Schema { get; }

        protected TrustedPlatformClient(Uri baseUri, bool debug)
        {
            Middleware = new TrustedPlatformMiddleware(baseUri, debug);
            Schema = new SchemaImpl(Middleware);
        }
    }
}
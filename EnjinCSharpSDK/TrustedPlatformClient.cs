using System;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public abstract class TrustedPlatformClient
    {
        public static readonly Uri KovanUrl = new Uri("https://kovan.cloud.enjin.io/");
        public static readonly Uri MainNetUrl = new Uri("https://cloud.enjin.io/");
        
        public TrustedPlatformMiddleware Middleware { get; }
        public ISharedSchema Schema { get; }

        protected TrustedPlatformClient(Uri baseUri, bool debug, string schema)
        {
            Middleware = new TrustedPlatformMiddleware(baseUri, debug, schema);
            Schema = new SchemaImpl(Middleware);
        }
    }
}
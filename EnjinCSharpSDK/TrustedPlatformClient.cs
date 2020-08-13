using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public abstract class TrustedPlatformClient
    {
        internal TrustedPlatformMiddleware Middleware { get; }

        private protected Schema SchemaInstance;

        protected TrustedPlatformClient(Uri baseUri, bool debug, string schema)
        {
            Middleware = new TrustedPlatformMiddleware(baseUri, debug, schema);
            SchemaInstance = new Schema(Middleware);
        }
    }
}
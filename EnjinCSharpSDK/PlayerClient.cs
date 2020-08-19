using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class PlayerClient : PlayerSchema.PlayerSchema
    {
        public PlayerClient(Uri baseUri, bool debug = false)
            : base(new TrustedPlatformMiddleware(baseUri, debug))
        {
        }
    }
}
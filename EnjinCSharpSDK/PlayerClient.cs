using System;
using Enjin.SDK.PlayerSchema;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class PlayerClient : TrustedPlatformClient
    {
        public new IPlayerSchema Schema { get; }

        public PlayerClient(Uri baseUri, bool debug) : base(baseUri, debug, "player")
        {
        }
    }
}
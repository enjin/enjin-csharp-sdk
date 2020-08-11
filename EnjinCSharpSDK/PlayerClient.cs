using System;
using Enjin.SDK.PlayerSchema;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class PlayerClient : TrustedPlatformClient
    {
        private const string SCHEMA = "player";
        
        public PlayerClient(Uri baseUri, bool debug = false) : base(baseUri, debug, SCHEMA)
        {
        }

        public IPlayerSchema Schema => SchemaInstance;
    }
}
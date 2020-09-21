using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Client for using the player schema.
    /// </summary>
    /// <seealso cref="EnjinHosts"/>
    [PublicAPI]
    public class PlayerClient : PlayerSchema.PlayerSchema
    {
        /// <summary>
        /// Constructs a client with the targeted URI.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        public PlayerClient(Uri baseUri, bool debug = false)
            : base(new TrustedPlatformMiddleware(baseUri, debug))
        {
        }
    }
}
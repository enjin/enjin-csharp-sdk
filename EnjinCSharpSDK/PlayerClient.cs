using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Client for using the player schema.
    /// </summary>
    /// <seealso cref="EnjinHosts"/>
    [PublicAPI]
    public class PlayerClient : PlayerSchema.PlayerSchema, IClient
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
        
        /// <inheritdoc/>
        public bool IsAuthenticated => Middleware.HttpHandler.IsAuthenticated;

        /// <inheritdoc/>
        public void Auth(string? token)
        {
            Middleware.HttpHandler.AuthToken = token;
        }
    }
}
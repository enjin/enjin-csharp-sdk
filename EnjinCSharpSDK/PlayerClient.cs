using System;
using Enjin.SDK.Utils;
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
        /// Constructs a client with the targeted URI, debug setting, and a default logger provider.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        public PlayerClient(Uri baseUri, bool debug = false) :
            this(baseUri, LoggerProvider.CreateDefaultLoggerProvider(), debug)
        {
        }

        /// <summary>
        /// Constructs a client with the given URI, logger provider, and debug setting.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        public PlayerClient(Uri baseUri, LoggerProvider loggerProvider, bool debug = false) :
            base(new TrustedPlatformMiddleware(baseUri, debug), loggerProvider)
        {
        }

        /// <inheritdoc/>
        public bool IsAuthenticated => Middleware.HttpHandler.IsAuthenticated;

        /// <inheritdoc/>
        public bool IsClosed { get; private set; }

        /// <inheritdoc/>
        public void Auth(string? token)
        {
            Middleware.HttpHandler.AuthToken = token;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Middleware.HttpClient.Dispose();
            IsClosed = true;
        }
    }
}
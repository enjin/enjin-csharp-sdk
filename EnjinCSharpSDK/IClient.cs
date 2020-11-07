using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Interface for client implementation.
    /// </summary>
    [PublicAPI]
    public interface IClient : IDisposable
    {
        /// <summary>
        /// Represents whether the client is authenticated.
        /// </summary>
        /// <value>Whether the client is authenticated.</value>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Represents whether the client is closed.
        /// </summary>
        /// <value>Whether the client is closed.</value>
        bool IsClosed { get; }
        
        /// <summary>
        /// Authenticates the client with the given token.
        /// </summary>
        /// <param name="token">The auth token.</param>
        void Auth(string? token);
    }
}
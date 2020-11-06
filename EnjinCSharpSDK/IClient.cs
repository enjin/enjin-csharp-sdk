using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Interface for client implementation.
    /// </summary>
    [PublicAPI]
    public interface IClient
    {
        /// <summary>
        /// Represents whether the client is authenticated.
        /// </summary>
        /// <value>Whether the client is authenticated.</value>
        bool IsAuthenticated { get; }
        
        /// <summary>
        /// Authenticates the client with the given token.
        /// </summary>
        /// <param name="token">The auth token.</param>
        void Auth(string? token);
    }
}
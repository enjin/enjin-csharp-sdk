using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to obtain an access token for a player.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.AccessToken"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class AuthPlayer : GraphqlRequest<AuthPlayer>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public AuthPlayer() : base("enjin.sdk.project.AuthPlayer")
        {
        }
        
        /// <summary>
        /// Sets the player ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public AuthPlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
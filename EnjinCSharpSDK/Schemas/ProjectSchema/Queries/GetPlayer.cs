using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for getting a player on the project.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Player"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetPlayer : GraphqlRequest<GetPlayer>, IPlayerFragmentArguments<GetPlayer>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetPlayer() : base("enjin.sdk.project.GetPlayer")
        {
        }
        
        /// <summary>
        /// Sets the player ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetPlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
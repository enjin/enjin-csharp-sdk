using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for creating a player for the project.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class CreatePlayer : GraphqlRequest<CreatePlayer>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CreatePlayer() : base("enjin.sdk.project.CreatePlayer")
        {
        }
        
        /// <summary>
        /// Sets the ID of the player.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public CreatePlayer Id(string? id)
        {
            return SetVariable("id", id);
        }
    }
}
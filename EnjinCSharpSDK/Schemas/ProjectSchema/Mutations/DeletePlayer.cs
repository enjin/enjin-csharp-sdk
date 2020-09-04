using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for deleting a player from the application.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class DeletePlayer : GraphqlRequest<DeletePlayer>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public DeletePlayer() : base("enjin.sdk.project.DeletePlayer")
        {
        }
        
        /// <summary>
        /// Sets the ID for the player to be deleted.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public DeletePlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
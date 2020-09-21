using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for invalidating the cached metadata of a token (item) on the platform.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class InvalidateTokenMetadata : GraphqlRequest<InvalidateTokenMetadata>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public InvalidateTokenMetadata() : base("enjin.sdk.project.InvalidateTokenMetadata")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public InvalidateTokenMetadata Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
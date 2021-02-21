using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for invalidating the cached metadata of a asset on the platform.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class InvalidateAssetMetadata : GraphqlRequest<InvalidateAssetMetadata>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public InvalidateAssetMetadata() : base("enjin.sdk.project.InvalidateAssetMetadata")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public InvalidateAssetMetadata Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
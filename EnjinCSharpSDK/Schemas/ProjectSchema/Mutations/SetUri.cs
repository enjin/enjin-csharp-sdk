using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to set the URI for the metadata of an asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetUri : GraphqlRequest<SetUri>, ITransactionRequestArguments<SetUri>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetUri() : base("enjin.sdk.project.SetUri")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri AssetId(string assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri AssetIndex(string assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }
        
        /// <summary>
        /// Sets the new URI for the asset's metadata.
        /// </summary>
        /// <param name="uri">The new URI.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri Uri(string uri)
        {
            return SetVariable("uri", uri);
        }
    }
}
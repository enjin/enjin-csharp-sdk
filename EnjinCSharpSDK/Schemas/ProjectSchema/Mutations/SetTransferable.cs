using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting if a asset may be transferred.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetTransferable : GraphqlRequest<SetTransferable>, ITransactionRequestArguments<SetTransferable>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetTransferable() : base("enjin.sdk.project.SetTransferable")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable AssetId(string assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable AssetIndex(string assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }
        
        /// <summary>
        /// Sets the new transfer mode.
        /// </summary>
        /// <param name="transferable">The new mode.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable Transferable(AssetTransferable? transferable)
        {
            return SetVariable("transferable", transferable);
        }
    }
}
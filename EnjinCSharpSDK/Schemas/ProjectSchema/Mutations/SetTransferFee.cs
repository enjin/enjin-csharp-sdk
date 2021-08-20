using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting the transfer fee of a asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetTransferFee : GraphqlRequest<SetTransferFee>, IProjectTransactionRequestArguments<SetTransferFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetTransferFee() : base("enjin.sdk.project.SetTransferFee")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee AssetIndex(string? assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }
        
        /// <summary>
        /// Sets the new transfer fee value in Wei.
        /// </summary>
        /// <param name="transferFee">The new transfer fee.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee TransferFee(string? transferFee)
        {
            return SetVariable("transferFee", transferFee);
        }
    }
}
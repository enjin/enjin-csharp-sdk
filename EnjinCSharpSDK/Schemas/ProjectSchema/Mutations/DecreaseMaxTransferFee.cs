using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting an asset's max transfer fee to a lower value.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class DecreaseMaxTransferFee : GraphqlRequest<DecreaseMaxTransferFee>, IProjectTransactionRequestArguments<DecreaseMaxTransferFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public DecreaseMaxTransferFee() : base("enjin.sdk.project.DecreaseMaxTransferFee")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxTransferFee AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the new max transfer in Wei.
        /// </summary>
        /// <param name="maxTransferFee">The new fee.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxTransferFee MaxTransferFee(int? maxTransferFee)
        {
            return SetVariable("maxTransferFee", maxTransferFee);
        }
    }
}
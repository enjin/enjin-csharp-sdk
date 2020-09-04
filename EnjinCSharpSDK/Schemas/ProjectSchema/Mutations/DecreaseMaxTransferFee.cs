using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting an item's max transfer fee to a lower value.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class DecreaseMaxTransferFee : GraphqlRequest<DecreaseMaxTransferFee>, ITransactionRequestArguments<DecreaseMaxTransferFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public DecreaseMaxTransferFee() : base("enjin.sdk.project.DecreaseMaxTransferFee")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxTransferFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxTransferFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
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
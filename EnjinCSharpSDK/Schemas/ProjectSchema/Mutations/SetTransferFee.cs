using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting the transfer fee of a item.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetTransferFee : GraphqlRequest<SetTransferFee>, ITransactionRequestArguments<SetTransferFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetTransferFee() : base("enjin.sdk.project.SetTransferFee")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        /// <summary>
        /// Sets the new transfer fee value in Wei.
        /// </summary>
        /// <param name="transferFee">The new transfer fee.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee TransferFee(string transferFee)
        {
            return SetVariable("transferFee", transferFee);
        }
    }
}
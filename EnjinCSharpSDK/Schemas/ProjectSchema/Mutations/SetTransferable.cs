using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting if a item may be transferred.
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
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        /// <summary>
        /// Sets the new transfer mode.
        /// </summary>
        /// <param name="transferable">The new mode.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable Transferable(TokenTransferable? transferable)
        {
            return SetVariable("transferable", transferable);
        }
    }
}
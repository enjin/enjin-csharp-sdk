using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to update the name of a token (item) on the platform.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class UpdateName : GraphqlRequest<UpdateName>, ITransactionRequestArguments<UpdateName>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public UpdateName() : base("enjin.sdk.project.UpdateName")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public UpdateName TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public UpdateName TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        /// <summary>
        /// Sets the name the token (item) will update to.
        /// </summary>
        /// <param name="name">The new name.</param>
        /// <returns>This request for chaining.</returns>
        public UpdateName Name(string name)
        {
            return SetVariable("name", name);
        }
    }
}
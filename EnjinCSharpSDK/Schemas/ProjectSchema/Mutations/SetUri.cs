using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to set the URI for the metadata of an item.
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
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        /// <summary>
        /// Sets the new URI for the item's metadata.
        /// </summary>
        /// <param name="uri">The new URI.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri Uri(string uri)
        {
            return SetVariable("uri", uri);
        }
    }
}
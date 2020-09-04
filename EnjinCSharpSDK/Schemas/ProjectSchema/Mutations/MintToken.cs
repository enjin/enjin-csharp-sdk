using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for minting a token (item).
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class MintToken : GraphqlRequest<MintToken>, ITransactionRequestArguments<MintToken>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public MintToken() : base("enjin.sdk.project.MintToken")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public MintToken TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the mints to be performed.
        /// </summary>
        /// <param name="mints">The mints.</param>
        /// <returns>This request for chaining.</returns>
        public MintToken Mints(List<MintInput> mints)
        {
            return SetVariable("mints", mints);
        }
    }
}
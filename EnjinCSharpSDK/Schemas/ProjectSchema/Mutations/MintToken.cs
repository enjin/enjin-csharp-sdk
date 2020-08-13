using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class MintToken : GraphqlRequest<MintToken>, ITransactionRequestArguments<MintToken>
    {
        protected MintToken() : base("enjin.sdk.project.MintToken")
        {
        }
        
        public MintToken TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public MintToken Mints(List<MintInput> mints)
        {
            return SetVariable("mints", mints);
        }
    }
}
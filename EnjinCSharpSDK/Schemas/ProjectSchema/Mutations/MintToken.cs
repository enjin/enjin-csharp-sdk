using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class MintToken<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected MintToken() : base("enjin.sdk.project.MintToken")
        {
        }
        
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T Mints(List<MintInput> mints)
        {
            return SetVariable("mints", mints);
        }
    }
    
    [PublicAPI]
    public class MintToken : MintToken<MintToken>
    {
    }
}
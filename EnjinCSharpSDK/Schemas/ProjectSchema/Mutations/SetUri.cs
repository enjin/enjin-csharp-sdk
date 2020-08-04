using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetUri<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected SetUri() : base("enjin.sdk.project.SetUri")
        {
        }
        
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public T Uri(string uri)
        {
            return SetVariable("uri", uri);
        }
    }

    [PublicAPI]
    public class SetUri : SetUri<SetUri>
    {
    }
}
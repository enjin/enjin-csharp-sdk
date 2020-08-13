using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetUri : GraphqlRequest<SetUri>, ITransactionRequestArguments<SetUri>
    {
        public SetUri() : base("enjin.sdk.project.SetUri")
        {
        }
        
        public SetUri TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public SetUri TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public SetUri Uri(string uri)
        {
            return SetVariable("uri", uri);
        }
    }
}
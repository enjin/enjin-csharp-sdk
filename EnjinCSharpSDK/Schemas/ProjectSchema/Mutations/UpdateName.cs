using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class UpdateName : GraphqlRequest<UpdateName>, ITransactionRequestArguments<UpdateName>
    {
        public UpdateName() : base("enjin.sdk.project.UpdateName")
        {
        }
        
        public UpdateName TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public UpdateName TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public UpdateName Name(string name)
        {
            return SetVariable("name", name);
        }
    }
}
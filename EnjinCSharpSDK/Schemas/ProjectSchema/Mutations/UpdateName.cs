using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class UpdateName<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected UpdateName() : base("enjin.sdk.project.UpdateName")
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
        
        public T Name(string name)
        {
            return SetVariable("name", name);
        }
    }

    [PublicAPI]
    public class UpdateName : UpdateName<UpdateName>
    {
    }
}
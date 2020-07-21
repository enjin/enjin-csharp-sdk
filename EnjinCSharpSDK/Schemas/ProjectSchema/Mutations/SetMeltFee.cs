using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetMeltFee<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public T MeltFee(int meltFee)
        {
            return SetVariable("meltFee", meltFee);
        }
    }

    [PublicAPI]
    public class SetMeltFee : SetMeltFee<SetMeltFee>
    {
    }
}
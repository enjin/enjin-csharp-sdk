using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class DecreaseMaxMeltFee<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected DecreaseMaxMeltFee() : base("enjin.sdk.project.DecreaseMaxMeltFee")
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
        
        public T MaxMeltFee(int maxMeltFee)
        {
            return SetVariable("maxMeltFee", maxMeltFee);
        }
    }

    [PublicAPI]
    public class DecreaseMaxMeltFee : DecreaseMaxMeltFee<DecreaseMaxMeltFee>
    {
    }
}
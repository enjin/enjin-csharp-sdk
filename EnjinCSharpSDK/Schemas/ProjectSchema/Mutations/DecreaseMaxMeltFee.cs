using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class DecreaseMaxMeltFee : GraphqlRequest<DecreaseMaxMeltFee>, ITransactionRequestArguments<DecreaseMaxMeltFee>
    {
        protected DecreaseMaxMeltFee() : base("enjin.sdk.project.DecreaseMaxMeltFee")
        {
        }
        
        public DecreaseMaxMeltFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public DecreaseMaxMeltFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public DecreaseMaxMeltFee MaxMeltFee(int maxMeltFee)
        {
            return SetVariable("maxMeltFee", maxMeltFee);
        }
    }
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetMeltFee : GraphqlRequest<SetMeltFee>, ITransactionRequestArguments<SetMeltFee>
    {
        public SetMeltFee() : base("enjin.sdk.project.SetMeltFee")
        {
        }
        
        public SetMeltFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public SetMeltFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public SetMeltFee MeltFee(int meltFee)
        {
            return SetVariable("meltFee", meltFee);
        }
    }
}
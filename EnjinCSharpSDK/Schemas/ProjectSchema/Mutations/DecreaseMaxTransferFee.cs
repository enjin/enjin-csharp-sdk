using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class DecreaseMaxTransferFee : GraphqlRequest<DecreaseMaxTransferFee>, ITransactionRequestArguments<DecreaseMaxTransferFee>
    {
        public DecreaseMaxTransferFee() : base("enjin.sdk.project.DecreaseMaxTransferFee")
        {
        }
        
        public DecreaseMaxTransferFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public DecreaseMaxTransferFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public DecreaseMaxTransferFee MaxTransferFee(int? maxTransferFee)
        {
            return SetVariable("maxTransferFee", maxTransferFee);
        }
    }
}
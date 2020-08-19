using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetTransferFee : GraphqlRequest<SetTransferFee>, ITransactionRequestArguments<SetTransferFee>
    {
        public SetTransferFee() : base("enjin.sdk.project.SetTransferFee")
        {
        }
        
        public SetTransferFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public SetTransferFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public SetTransferFee TransferFeeSettings(TokenTransferFeeSettingsInput transferFeeSettings)
        {
            return SetVariable("transferFeeSettings", transferFeeSettings);
        }
    }
}
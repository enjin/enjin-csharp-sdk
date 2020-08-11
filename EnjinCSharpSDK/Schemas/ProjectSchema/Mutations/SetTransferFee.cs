using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetTransferFee<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected SetTransferFee() : base("enjin.sdk.project.SetTransferFee")
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
        
        public T TransferFeeSettings(TokenTransferFeeSettingsInput transferFeeSettings)
        {
            return SetVariable("transferFeeSettings", transferFeeSettings);
        }
    }

    [PublicAPI]
    public class SetTransferFee : SetTransferFee<SetTransferFee>
    {
    }
}
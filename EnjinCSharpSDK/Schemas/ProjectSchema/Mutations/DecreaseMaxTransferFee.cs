using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class DecreaseMaxTransferFee<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public T MaxTransferFee(int maxTransferFee)
        {
            return SetVariable("maxTransferFee", maxTransferFee);
        }
    }

    [PublicAPI]
    public class DecreaseMaxTransferFee : DecreaseMaxTransferFee<DecreaseMaxTransferFee>
    {
    }
}
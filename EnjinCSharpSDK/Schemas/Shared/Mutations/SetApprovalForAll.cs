using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class SetApprovalForAll<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected SetApprovalForAll() : base("enjin.sdk.shared.SetApprovalForAll")
        {
        }

        public T OperatorAddress(string operatorAddress)
        {
            return SetVariable("operatorAddress", operatorAddress);
        }

        public T Approved(bool approved)
        {
            return SetVariable("approved", approved);
        }
    }
    
    [PublicAPI]
    public class SetApprovalForAll : SetApprovalForAll<SetApprovalForAll>
    {}
}
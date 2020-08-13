using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class SetApprovalForAll : GraphqlRequest<SetApprovalForAll>, ITransactionRequestArguments<SetApprovalForAll>
    {
        public SetApprovalForAll() : base("enjin.sdk.shared.SetApprovalForAll")
        {
        }

        public SetApprovalForAll OperatorAddress(string operatorAddress)
        {
            return SetVariable("operatorAddress", operatorAddress);
        }

        public SetApprovalForAll Approved(bool approved)
        {
            return SetVariable("approved", approved);
        }
    }
}
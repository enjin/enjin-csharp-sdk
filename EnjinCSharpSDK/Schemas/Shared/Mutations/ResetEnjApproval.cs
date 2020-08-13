using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class ResetEnjApproval : GraphqlRequest<ResetEnjApproval>, ITransactionRequestArguments<ResetEnjApproval>
    {
        public ResetEnjApproval() : base("enjin.sdk.shared.ResetEnjApproval")
        {
        }
    }
}
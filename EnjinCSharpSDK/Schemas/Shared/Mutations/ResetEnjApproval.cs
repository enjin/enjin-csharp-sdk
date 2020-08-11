using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class ResetEnjApproval<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected ResetEnjApproval() : base("enjin.sdk.shared.ResetEnjApproval")
        {
        }
    }
    
    [PublicAPI]
    public class ResetEnjApproval : ResetEnjApproval<ResetEnjApproval>
    {
    }
}
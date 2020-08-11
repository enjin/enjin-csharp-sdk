using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class ApproveMaxEnj<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected ApproveMaxEnj() : base("enjin.sdk.shared.ApproveMaxEnj")
        {
        }
    }
    
    [PublicAPI]
    public class ApproveMaxEnj : ApproveMaxEnj<ApproveMaxEnj>
    {}
}
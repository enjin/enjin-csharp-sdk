using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class ApproveMaxEnj : GraphqlRequest<ApproveMaxEnj>, ITransactionRequestArguments<ApproveMaxEnj>
    {
        protected ApproveMaxEnj() : base("enjin.sdk.shared.ApproveMaxEnj")
        {
        }
    }
}
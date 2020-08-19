using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class ApproveEnj : GraphqlRequest<ApproveEnj>, ITransactionRequestArguments<ApproveEnj>
    {
        public ApproveEnj() : base("enjin.sdk.shared.ApproveEnj")
        {
        }

        public ApproveEnj Value(string value)
        {
            return SetVariable("value", value);
        }
    }
}
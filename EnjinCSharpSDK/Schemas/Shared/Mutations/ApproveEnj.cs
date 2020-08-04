using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class ApproveEnj<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected ApproveEnj() : base("enjin.sdk.shared.ApproveEnj")
        {
        }

        public T Value(string value)
        {
            return SetVariable("value", value);
        }
    }
    
    [PublicAPI]
    public class ApproveEnj : ApproveEnj<ApproveEnj>
    {}
}
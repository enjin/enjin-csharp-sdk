using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetRequests<T>: GraphqlRequest<T>, ITransactionFragmentArguments<T>, IPaginationArguments<T>
        where T : GraphqlRequest<T>, new()
    {
        protected GetRequests() : base("enjin.sdk.shared.GetRequests")
        {
        }

        public T Filter(TransactionFilter filter)
        {
            return SetVariable("filter", filter);
        }

        public T Sort(TransactionSort sort)
        {
            return SetVariable("sort", sort);
        }
    }

    [PublicAPI]
    public class GetRequests : GetRequests<GetRequests>
    {
    }
}
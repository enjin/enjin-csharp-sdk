using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetRequests : GraphqlRequest<GetRequests>, ITransactionFragmentArguments<GetRequests>, IPaginationArguments<GetRequests>
    {
        protected GetRequests() : base("enjin.sdk.shared.GetRequests")
        {
        }

        public GetRequests Filter(TransactionFilter filter)
        {
            return SetVariable("filter", filter);
        }

        public GetRequests Sort(TransactionSort sort)
        {
            return SetVariable("sort", sort);
        }
    }
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetBalances : GraphqlRequest<GetBalances>, IBalanceFragmentArguments<GetBalances>, IPaginationArguments<GetBalances>
    {
        public GetBalances() : base("enjin.sdk.shared.GetBalances")
        {
        }

        public GetBalances Filter(BalanceFilter filter)
        {
            return SetVariable("filter", filter);
        }
    }
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetBalances<T> : GraphqlRequest<T>, IBalanceFragmentArguments<T>, IPaginationArguments<T>
        where T : GraphqlRequest<T>, new()
    {
        protected GetBalances() : base("enjin.sdk.shared.GetBalances")
        {
        }

        public T Filter(BalanceFilter filter)
        {
            return SetVariable("filter", filter);
        }
    }
    
    [PublicAPI]
    public class GetBalances : GetBalances<GetBalances>
    {}
}
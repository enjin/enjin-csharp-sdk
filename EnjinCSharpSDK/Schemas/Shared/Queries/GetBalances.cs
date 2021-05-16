using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting balances on the platform.
    /// </summary>
    /// <seealso cref="Balance"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetBalances : GraphqlRequest<GetBalances>, IBalanceFragmentArguments<GetBalances>, IPaginationArguments<GetBalances>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetBalances() : base("enjin.sdk.shared.GetBalances")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetBalances Filter(BalanceFilter? filter)
        {
            return SetVariable("filter", filter);
        }
    }
}
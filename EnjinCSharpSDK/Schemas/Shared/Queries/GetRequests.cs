using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting transactions on the platform.
    /// </summary>
    /// <seealso cref="Request"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetRequests : GraphqlRequest<GetRequests>, ITransactionFragmentArguments<GetRequests>, IPaginationArguments<GetRequests>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetRequests() : base("enjin.sdk.shared.GetRequests")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetRequests Filter(TransactionFilter? filter)
        {
            return SetVariable("filter", filter);
        }

        /// <summary>
        /// Sets the request to sort the results by the specified options.
        /// </summary>
        /// <param name="sort">The sort options.</param>
        /// <returns>This request for chaining.</returns>
        public GetRequests Sort(TransactionSort? sort)
        {
            return SetVariable("sort", sort);
        }
    }
}
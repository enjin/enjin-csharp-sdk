using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting tokens (items) on the platform.
    /// </summary>
    /// <seealso cref="Token"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetTokens : GraphqlRequest<GetTokens>, ITokenFragmentArguments<GetTokens>, IPaginationArguments<GetTokens>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetTokens() : base("enjin.sdk.shared.GetTokens")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetTokens Filter(TokenFilter filter)
        {
            return SetVariable("filter", filter);
        }

        /// <summary>
        /// Sets the request to sort the results by the specified options.
        /// </summary>
        /// <param name="sort">The sort options.</param>
        /// <returns>This request for chaining.</returns>
        public GetTokens Sort(TokenSort sort)
        {
            return SetVariable("sort", sort);
        }
    }
}
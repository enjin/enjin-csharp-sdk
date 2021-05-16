using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting assets on the platform.
    /// </summary>
    /// <seealso cref="Asset"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetAssets : GraphqlRequest<GetAssets>, IAssetFragmentArguments<GetAssets>, IPaginationArguments<GetAssets>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetAssets() : base("enjin.sdk.shared.GetAssets")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetAssets Filter(AssetFilter? filter)
        {
            return SetVariable("filter", filter);
        }

        /// <summary>
        /// Sets the request to sort the results by the specified options.
        /// </summary>
        /// <param name="sort">The sort options.</param>
        /// <returns>This request for chaining.</returns>
        public GetAssets Sort(AssetSort? sort)
        {
            return SetVariable("sort", sort);
        }
    }
}
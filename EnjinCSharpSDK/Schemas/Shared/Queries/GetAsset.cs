using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting a asset on the platform.
    /// </summary>
    /// <seealso cref="Asset"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetAsset : GraphqlRequest<GetAsset>, IAssetFragmentArguments<GetAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetAsset() : base("enjin.sdk.shared.GetAsset")
        {
        }

        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetAsset Id(string? id)
        {
            return SetVariable("id", id);
        }
    }
}
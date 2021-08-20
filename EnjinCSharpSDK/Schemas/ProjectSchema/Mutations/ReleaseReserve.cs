using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for releasing the reserve of an asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class ReleaseReserve : GraphqlRequest<ReleaseReserve>, IProjectTransactionRequestArguments<ReleaseReserve>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ReleaseReserve() : base("enjin.sdk.project.ReleaseReserve")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public ReleaseReserve AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the amount to release.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This request for chaining.</returns>
        public ReleaseReserve Value(string? value)
        {
            return SetVariable("value", value);
        }
    }
}
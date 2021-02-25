using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting the melt fee of an asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetMeltFee : GraphqlRequest<SetMeltFee>, ITransactionRequestArguments<SetMeltFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetMeltFee() : base("enjin.sdk.project.SetMeltFee")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetMeltFee AssetId(string assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetMeltFee AssetIndex(string assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }
        
        /// <summary>
        /// Sets the new melt fee for the asset.
        /// </summary>
        /// <param name="meltFee">The new ratio.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The ratio is in the range 0-5000 to allow for fractional ratios, e.g. 1 = 0.01%, 5000 = 50%, ect...
        /// </remarks>
        public SetMeltFee MeltFee(int? meltFee)
        {
            return SetVariable("meltFee", meltFee);
        }
    }
}
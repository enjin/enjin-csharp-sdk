using Enjin.SDK.Shared;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a melt input for melt requests.
    /// </summary>
    /// <seealso cref="MeltAsset"/>
    [PublicAPI]
    public class Melt
    {
        [JsonProperty("assetId")]
        private string? _assetId;
        [JsonProperty("assetIndex")]
        private string? _assetIndex;
        [JsonProperty("value")]
        private string? _value;

        /// <summary>
        /// Sets the asset ID to melt.
        /// </summary>
        /// <param name="assetId">The asset ID.</param>
        /// <returns>This input for chaining.</returns>
        public Melt AssetId(string? assetId)
        {
            _assetId = assetId;
            return this;
        }

        /// <summary>
        /// Sets the index of a non-fungible asset to melt.
        /// </summary>
        /// <param name="assetIndex">The asset index.</param>
        /// <returns>This input for chaining.</returns>
        public Melt AssetIndex(string? assetIndex)
        {
            _assetIndex = assetIndex;
            return this;
        }

        /// <summary>
        /// Sets the number of assets to melt.
        /// </summary>
        /// <param name="value">The amount of assets.</param>
        /// <returns>This input for chaining.</returns>
        public Melt Value(string? value)
        {
            _value = value;
            return this;
        }
    }
}
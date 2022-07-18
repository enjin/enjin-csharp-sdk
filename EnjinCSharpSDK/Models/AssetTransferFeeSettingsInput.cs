using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models input for the transfer fee settings used in asset requests.
    /// </summary>
    [PublicAPI]
    public class AssetTransferFeeSettingsInput
    {
        [JsonProperty("type")]
        private AssetTransferFeeType? _type;

        [JsonProperty("assetId")]
        private string? _assetId;

        [JsonProperty("value")]
        private string? _value;

        /// <summary>
        /// Sets the transfer type for this input.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>This input for chaining.</returns>
        public AssetTransferFeeSettingsInput Type(AssetTransferFeeType? type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        /// Sets the asset ID for this input.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This input for chaining.</returns>
        /// <remarks>
        /// If the ID is set to "0", then this will be set to transfer ENJ instead of a asset.
        /// </remarks>
        public AssetTransferFeeSettingsInput AssetId(string? assetId)
        {
            _assetId = assetId;
            return this;
        }

        /// <summary>
        /// Sets the value in Wei for this input.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This input for chaining.</returns>
        public AssetTransferFeeSettingsInput Value(string? value)
        {
            _value = value;
            return this;
        }
    }
}
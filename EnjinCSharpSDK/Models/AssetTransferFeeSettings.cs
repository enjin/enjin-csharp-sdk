using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models transfer fee settings for an asset.
    /// </summary>
    /// <seealso cref="Asset"/>
    [PublicAPI]
    public class AssetTransferFeeSettings
    {
        /// <summary>
        /// Represents the transfer fee type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public AssetTransferFeeType? Type { get; internal set; }
        
        /// <summary>
        /// Represents the asset ID or "0" if ENJ.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("assetId")]
        public string? AssetId { get; internal set; }
        
        /// <summary>
        /// Represents the fee value in Wei.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string? Value { get; internal set; }
    }

    /// <summary>
    /// Models input for the transfer fee settings used in asset requests.
    /// </summary>
    [PublicAPI]
    public class AssetTransferFeeSettingsInput: AssetTransferFeeSettings
    {
        /// <summary>
        /// Sets the transfer type for this input.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>This input for chaining.</returns>
        public AssetTransferFeeSettingsInput Type(AssetTransferFeeType? type)
        {
            base.Type = type;
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
            base.AssetId = assetId;
            return this;
        }

        /// <summary>
        /// Sets the value in Wei for this input.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This input for chaining.</returns>
        public AssetTransferFeeSettingsInput Value(string? value)
        {
            base.Value = value;
            return this;
        }
    }
}
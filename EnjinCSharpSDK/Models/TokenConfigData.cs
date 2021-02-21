using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the configuration data of a <see cref="Token"/>.
    /// </summary>
    [PublicAPI]
    public class TokenConfigData
    {
        /// <summary>
        /// Represents the melt fee ratio of this item.
        /// </summary>
        /// <value>The ratio.</value>
        /// <remarks>
        /// The ratio is in the range of 0-10000 to allow for fractional ratios. e.g. 1 = 0.01%, 10000 = 100%, ect...
        /// </remarks>
        [JsonProperty("meltFeeRatio")]
        public int? MeltFeeRatio { get; private set; }
        
        /// <summary>
        /// Represents the max melt fee ratio for this item.
        /// </summary>
        /// <value>The ratio.</value>
        /// <remarks>
        /// The ratio is in the range of 0-10000 to allow for fractional ratios. e.g. 1 = 0.01%, 10000 = 100%, ect...
        /// </remarks>
        [JsonProperty("meltFeeMaxRatio")]
        public int? MeltFeeMaxRatio { get; private set; }
        
        /// <summary>
        /// The melt value for this item. This value corresponds to its exchange rate.
        /// </summary>
        /// <value>The melt value.</value>
        [JsonProperty("meltValue")]
        public string? MeltValue { get; private set; }
        
        /// <summary>
        /// Represents the URI for the metadata of this item.
        /// </summary>
        /// <value>The URI.</value>
        [JsonProperty("metadataURI")]
        public string? MetadataUri { get; private set; }

        /// <summary>
        /// Represents the transferable type of this item.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("transferable")]
        public TokenTransferable? Transferable { get; private set; }
        
        /// <summary>
        /// Represents the transfer fee settings for this item.
        /// </summary>
        /// <value>The settings.</value>
        [JsonProperty("transferFeeSettings")]
        public TokenTransferFeeSettings? TransferFeeSettings { get; private set; }
    }
}
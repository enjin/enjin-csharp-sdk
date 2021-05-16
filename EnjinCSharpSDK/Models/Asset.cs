using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a asset on the platform.
    /// </summary>
    [PublicAPI]
    public class Asset
    {
        /// <summary>
        /// Represents the base ID of this asset.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public string? Id { get; private set; }

        /// <summary>
        /// Represents the name of this asset.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; private set; }
        
        /// <summary>
        /// Represents the state data of this asset.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("stateData")]
        public AssetStateData? StateData { get; private set; }
        
        /// <summary>
        /// Represents the configuration data of this asset.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("configData")]
        public AssetConfigData? ConfigData { get; private set; }
        
        /// <summary>
        /// Represents the variant mode of this asset.
        /// </summary>
        /// <value>The variant mode.</value>
        [JsonProperty("variantMode")]
        public AssetVariantMode? VariantMode { get; private set; }
        
        /// <summary>
        /// Represents variants of this asset.
        /// </summary>
        /// <value>The variants.</value>
        [JsonProperty("variants")]
        public List<AssetVariant>? Variants { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this asset was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this asset was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; private set; }
    }
}
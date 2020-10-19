using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a item on the platform.
    /// </summary>
    [PublicAPI]
    public class Token
    {
        /// <summary>
        /// Represents the base ID of this item.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public string Id { get; private set; } = null!;

        /// <summary>
        /// Represents the name of this item.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; private set; } = null!;
        
        /// <summary>
        /// Represents the state data of this item.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("stateData")]
        public TokenStateData? StateData { get; private set; }
        
        /// <summary>
        /// Represents the configuration data of this item.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("configData")]
        public TokenConfigData? ConfigData { get; private set; }
        
        /// <summary>
        /// Represents the token variant mode of this item.
        /// </summary>
        /// <value>The variant mode.</value>
        [JsonProperty("variantMode")]
        public TokenVariantMode? VariantMode { get; private set; }
        
        /// <summary>
        /// Represents token variants of this item.
        /// </summary>
        /// <value>The variants.</value>
        [JsonProperty("variants")]
        public List<TokenVariant>? Variants { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this item was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; } = null!;
        
        /// <summary>
        /// Represents the datetime when this item was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; } = null!;
    }
}
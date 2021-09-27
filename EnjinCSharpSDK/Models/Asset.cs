/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
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

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a asset variant.
    /// </summary>
    [PublicAPI]
    public class AssetVariant
    {
        /// <summary>
        /// Represents the ID of this variant.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public int? Id { get; private set; }
        
        /// <summary>
        /// Represents the ID of the asset this variant belongs to.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("assetId")]
        public string? AssetId { get; private set; }
        
        /// <summary>
        /// Represents the metadata for this variant.
        /// </summary>
        /// <value>The metadata.</value>
        [JsonProperty("variantMetadata")]
        public JObject? VariantMetadata { get; private set; }
        
        /// <summary>
        /// Represents the usage count of this variant.
        /// </summary>
        /// <value>The usage count.</value>
        [JsonProperty("usageCount")]
        public int? UsageCount { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this variant was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this variant was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; private set; }
    }
}
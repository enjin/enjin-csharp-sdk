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
        public AssetTransferFeeType? Type { get; private set; }

        /// <summary>
        /// Represents the asset ID or "0" if ENJ.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("assetId")]
        public string? AssetId { get; private set; }

        /// <summary>
        /// Represents the fee value in Wei.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string? Value { get; private set; }
    }
}
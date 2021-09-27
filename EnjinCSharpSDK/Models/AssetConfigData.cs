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
    /// Models the configuration data of a <see cref="Asset"/>.
    /// </summary>
    [PublicAPI]
    public class AssetConfigData
    {
        /// <summary>
        /// Represents the melt fee ratio of the asset.
        /// </summary>
        /// <value>The ratio.</value>
        /// <remarks>
        /// The ratio is in the range of 0-10000 to allow for fractional ratios. e.g. 1 = 0.01%, 10000 = 100%, ect...
        /// </remarks>
        [JsonProperty("meltFeeRatio")]
        public int? MeltFeeRatio { get; private set; }
        
        /// <summary>
        /// Represents the max melt fee ratio for the asset.
        /// </summary>
        /// <value>The ratio.</value>
        /// <remarks>
        /// The ratio is in the range of 0-10000 to allow for fractional ratios. e.g. 1 = 0.01%, 10000 = 100%, ect...
        /// </remarks>
        [JsonProperty("meltFeeMaxRatio")]
        public int? MeltFeeMaxRatio { get; private set; }
        
        /// <summary>
        /// The melt value for the asset. This value corresponds to its exchange rate.
        /// </summary>
        /// <value>The melt value.</value>
        [JsonProperty("meltValue")]
        public string? MeltValue { get; private set; }
        
        /// <summary>
        /// Represents the URI for the metadata of the asset.
        /// </summary>
        /// <value>The URI.</value>
        [JsonProperty("metadataURI")]
        public string? MetadataUri { get; private set; }

        /// <summary>
        /// Represents the transferable type of the asset.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("transferable")]
        public AssetTransferable? Transferable { get; private set; }
        
        /// <summary>
        /// Represents the transfer fee settings for the asset.
        /// </summary>
        /// <value>The settings.</value>
        [JsonProperty("transferFeeSettings")]
        public AssetTransferFeeSettings? TransferFeeSettings { get; private set; }
    }
}
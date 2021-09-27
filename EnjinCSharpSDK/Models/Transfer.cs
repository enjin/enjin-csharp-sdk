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

using Enjin.SDK.Shared;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models transfer input when making requests.
    /// </summary>
    /// <seealso cref="AdvancedSendAsset"/>
    [PublicAPI]
    public class Transfer
    {
        [JsonProperty("from")]
        private string? _from;
        [JsonProperty("to")]
        private string? _to;
        [JsonProperty("assetId")]
        private string? _assetId;
        [JsonProperty("assetIndex")]
        private string? _assetIndex;
        [JsonProperty("value")]
        private string? _value;

        /// <summary>
        /// Sets the source of the funds.
        /// </summary>
        /// <param name="address">The source.</param>
        /// <returns>This input chaining.</returns>
        public Transfer From(string? address)
        {
            _from = address;
            return this;
        }
        
        /// <summary>
        /// Sets the destination of the funds.
        /// </summary>
        /// <param name="address">The destination.</param>
        /// <returns>This input chaining.</returns>
        public Transfer To(string? address)
        {
            _to = address;
            return this;
        }
        
        /// <summary>
        /// Sets the asset ID to transfer or ENJ if not used or set to <c>null</c>.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This input chaining.</returns>
        public Transfer AssetId(string? id)
        {
            _assetId = id;
            return this;
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>This input chaining.</returns>
        public Transfer AssetIndex(string? index)
        {
            _assetIndex = index;
            return this;
        }
        
        /// <summary>
        /// Sets the number of assets to transfer.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This input chaining.</returns>
        /// <remarks>
        /// If transferring ENJ, the value is the amount to send in Wei (10^18 e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public Transfer Value(string? value)
        {
            _value = value;
            return this;
        }
    }
}
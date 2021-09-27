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
    /// Models a trade input for requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.CreateTrade"/>
    [PublicAPI]
    public class Trade
    {
        [JsonProperty("assetId")]
        private string? _assetId;
        [JsonProperty("assetIndex")]
        private string? _assetIndex;
        [JsonProperty("value")]
        private string? _value;

        /// <summary>
        /// Sets the asset ID to trade or ENJ if not used or set to <c>null</c>.
        /// </summary>
        /// <param name="assetId">The asset ID.</param>
        /// <returns>This input for chaining.</returns>
        public Trade AssetId(string? assetId)
        {
            _assetId = assetId;
            return this;
        }

        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The asset index.</param>
        /// <returns>This input for chaining.</returns>
        public Trade AssetIndex(string? assetIndex)
        {
            _assetIndex = assetIndex;
            return this;
        }

        /// <summary>
        /// Sets the number of assets to trade.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This input for chaining.</returns>
        /// <remarks>
        /// If trading ENJ, the value is the amount to send in Wei (10^18 e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public Trade Value(string? value)
        {
            _value = value;
            return this;
        }
    }
}
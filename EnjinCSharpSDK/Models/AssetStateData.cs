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
    /// Models the state data of a <see cref="Asset"/>.
    /// </summary>
    [PublicAPI]
    public class AssetStateData
    {
        /// <summary>
        /// Represents the fungible state of this asset.
        /// </summary>
        /// <value>Whether this asset is non-fungible.</value>
        [JsonProperty("nonFungible")]
        public bool? NonFungible { get; private set; }
        
        /// <summary>
        /// Represents the block number of the last update.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("blockHeight")]
        public int? BlockHeight { get; private set; }
        
        /// <summary>
        /// Represents the wallet address of the creator of the asset.
        /// </summary>
        /// <value>The creator's address.</value>
        [JsonProperty("creator")]
        public string? Creator { get; private set; }
        
        /// <summary>
        /// Represents the first block the asset appeared in.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("firstBlock")]
        public int? FirstBlock { get; private set; }

        /// <summary>
        /// Represents the reserve of the asset.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("reserve")]
        public string? Reserve { get; private set; }
        
        /// <summary>
        /// Represents the supply model for the asset.
        /// </summary>
        /// <value>The supply model.</value>
        [JsonProperty("supplyModel")]
        public AssetSupplyModel? SupplyModel { get; private set; }
        
        /// <summary>
        /// Represents the amount of the asset in circulation.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("circulatingSupply")]
        public string? CirculatingSupply { get; private set; }
        
        /// <summary>
        /// Represents the amount of the asset available for minting.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("mintableSupply")]
        public string? MintableSupply { get; private set; }
        
        /// <summary>
        /// Represents the total supply of the asset.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("totalSupply")]
        public string? TotalSupply { get; private set; }
    }
}
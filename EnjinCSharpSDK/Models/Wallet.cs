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
    /// Models a wallet on the platform.
    /// </summary>
    [PublicAPI]
    public class Wallet
    {
        /// <summary>
        /// Represents the Ethereum address of this wallet.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("ethAddress")]
        public string? EthAddress { get; private set; }
        
        /// <summary>
        /// Represents the ENJ allowance given to crypto items.
        /// </summary>
        /// <value>The allowance.</value>
        [JsonProperty("enjAllowance")]
        public float? EnjAllowance { get; private set; }
        
        /// <summary>
        /// Represents the ENJ balance for this wallet.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("enjBalance")]
        public float? EnjBalance { get; private set; }
        
        /// <summary>
        /// Represents the ETH balance for this wallet.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("ethBalance")]
        public float? EthBalance { get; private set; }
        
        /// <summary>
        /// Represents the assets this wallet has created.
        /// </summary>
        /// <value>The list of assets.</value>
        [JsonProperty("assetsCreated")]
        public List<Asset>? AssetsCreated { get; private set; }
    }
}
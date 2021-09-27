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
    /// Models a smart contract used by the platform.
    /// </summary>
    [PublicAPI]
    public class Contracts
    {
        /// <summary>
        /// Represents the ENJ contract address.
        /// </summary>
        /// <value>The contract address.</value>
        [JsonProperty("enj")]
        public string? Enj { get; private set; }
        
        /// <summary>
        /// Represents the crypto items contract address.
        /// </summary>
        /// <value>The contract address.</value>
        [JsonProperty("cryptoItems")]
        public string? CryptoItems { get; private set; }
        
        /// <summary>
        /// Represents the platform registry contract address.
        /// </summary>
        /// <value>The contract address.</value>
        [JsonProperty("platformRegistry")]
        public string? PlatformRegistry { get; private set; }
        
        /// <summary>
        /// Represents the supply models used by the platform.
        /// </summary>
        /// <value>The supply models.</value>
        [JsonProperty("supplyModels")]
        public SupplyModels? SupplyModels { get; private set; }
    }
}
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
    /// Models a asset balance.
    /// </summary>
    [PublicAPI]
    public class Balance
    {
        /// <summary>
        /// Represents the asset ID for this balance.
        /// </summary>
        /// <value>The ID of the asset.</value>
        [JsonProperty("id")]
        public string? Id { get; private set; }
        
        /// <summary>
        /// Represents the asset index for this balance.
        /// </summary>
        /// <value>The index of the asset.</value>
        [JsonProperty("index")]
        public string? Index { get; private set; }
        
        /// <summary>
        /// Represents the balance for the asset.
        /// </summary>
        /// <value>The amount in the balance.</value>
        [JsonProperty("value")]
        public int? Value { get; private set; }
        
        /// <summary>
        /// Represents the project for this balance's asset.
        /// </summary>
        /// <value>The project model.</value>
        [JsonProperty("project")]
        public Project? Project { get; private set; }
        
        /// <summary>
        /// Represents the wallet for this balance.
        /// </summary>
        /// <value>The wallet model.</value>
        [JsonProperty("wallet")]
        public Wallet? Wallet { get; private set; }
    }
}
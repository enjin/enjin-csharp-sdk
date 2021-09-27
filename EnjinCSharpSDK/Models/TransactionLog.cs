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
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a blockchain transaction log.
    /// </summary>
    [PublicAPI]
    public class TransactionLog
    {
        /// <summary>
        /// Represents the block number.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("blockNumber")]
        public int? BlockNumber { get; private set; }
        
        /// <summary>
        /// Represents the originating address.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("address")]
        public string? Address { get; private set; }
        
        /// <summary>
        /// Represents the hash of the transaction.
        /// </summary>
        /// <value>The transaction hash.</value>
        [JsonProperty("transactionHash")]
        public string? TransactionHash { get; private set; }
        
        /// <summary>
        /// Represents the list of data objects.
        /// </summary>
        /// <value>The list of data.</value>
        [JsonProperty("data")]
        public List<JObject>? Data { get; private set; }
        
        /// <summary>
        /// Represents the list of topics.
        /// </summary>
        /// <value>The list of topics.</value>
        [JsonProperty("topics")]
        public List<JObject>? Topics { get; private set; }
        
        /// <summary>
        /// Represents the transaction event.
        /// </summary>
        /// <value>The transaction event.</value>
        [JsonProperty("event")]
        public TransactionEvent? Event { get; private set; }
    }
}
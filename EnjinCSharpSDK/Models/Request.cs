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
    /// Models a transaction on the platform.
    /// </summary>
    [PublicAPI]
    public class Request
    {
        /// <summary>
        /// Represents the ID of this transaction.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public int? Id { get; private set; }

        /// <summary>
        /// Represents the hash ID of this transaction.
        /// </summary>
        /// <value>The hash ID.</value>
        [JsonProperty("transactionId")]
        public string? TransactionId { get; private set; }

        /// <summary>
        /// Represents the title of this transaction.
        /// </summary>
        /// <value>The transaction title.</value>
        [JsonProperty("title")]
        public string? Title { get; private set; }
        
        /// <summary>
        /// Represents the contract address for this transaction.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("contract")]
        public string? Contract { get; private set; }

        /// <summary>
        /// Represents the type of this transaction.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public RequestType? Type { get; private set; }
        
        /// <summary>
        /// Represents the value of this transaction.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string? Value { get; private set; }

        /// <summary>
        /// Represents the retry state for this transaction.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("retryState")]
        public string? RetryState { get; private set; }
        
        /// <summary>
        /// Represents the state of this transaction.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public RequestState? State { get; private set; }
        
        /// <summary>
        /// Represents if the transaction has been accepted or not.
        /// </summary>
        /// <value>Whether the transaction was accepted.</value>
        [JsonProperty("accepted")]
        public bool? Accepted { get; private set; }
        
        /// <summary>
        /// Represents if the wallet of the transaction is a project wallet.
        /// </summary>
        /// <value>Whether the wallet of the transaction is a project wallet.</value>
        [JsonProperty("projectWallet")]
        public bool? ProjectWallet { get; private set; }

        /// <summary>
        /// Represents the blockchain data of this transaction.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("blockchainData")]
        public BlockchainData? BlockchainData { get; private set; }
        
        /// <summary>
        /// Represents the project this transaction belongs to.
        /// </summary>
        /// <value>The project.</value>
        [JsonProperty("project")]
        public Project? Project { get; private set; }

        /// <summary>
        /// Represents the datetime when this transaction was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this transaction was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; private set; }
    }
}
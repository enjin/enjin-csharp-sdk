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
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the blockchain data of a <see cref="Request"/>.
    /// </summary>
    [PublicAPI]
    public class BlockchainData
    {
        /// <summary>
        /// Represents the encoded data of the transaction, ready for signing.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("encodedData")]
        public string? EncodedData { get; private set; }
        
        /// <summary>
        /// Represents the signed string for the transaction this data applies to.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedTransaction")]
        public string? SignedTransaction { get; private set; }
        
        /// <summary>
        /// Represents the signed backup string for the transaction this data applies to.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedBackupTransaction")]
        public string? SignedBackupTransaction { get; private set; }
        
        /// <summary>
        /// Represents the signed cancel string for the transaction this data applies to.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedCancelTransaction")]
        public string? SignedCancelTransaction { get; private set; }
        
        /// <summary>
        /// Represents the receipt for the transaction this data applies to.
        /// </summary>
        /// <value>The receipt.</value>
        [JsonProperty("receipt")]
        public TransactionReceipt? Receipt { get; private set; }
        
        /// <summary>
        /// Represents the error message for the transaction this data applies to, if one exists.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("error")]
        public string? Error { get; private set; }
        
        /// <summary>
        /// Represents the nonce for the transaction this data applies to.
        /// </summary>
        /// <value>The nonce.</value>
        [JsonProperty("nonce")]
        public string? Nonce { get; private set; }
    }
}
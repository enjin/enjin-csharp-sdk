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
    /// Models a blockchain transaction event.
    /// </summary>
    [PublicAPI]
    public class TransactionEvent
    {
        /// <summary>
        /// Represents the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; private set; }
        
        /// <summary>
        /// Represents the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        [JsonProperty("inputs")]
        public List<JObject>? Inputs { get; private set; }
        
        /// <summary>
        /// Represents the non-indexed parameters.
        /// </summary>
        /// <value>The non-indexed parameters.</value>
        [JsonProperty("nonIndexedInputs")]
        public List<JObject>? NonIndexedInputs { get; private set; }
        
        /// <summary>
        /// Represents the indexed parameters.
        /// </summary>
        /// <value>The indexed parameters.</value>
        [JsonProperty("indexedInputs")]
        public List<JObject>? IndexedInputs { get; private set; }
        
        /// <summary>
        /// Represents the event signature, or <c>null</c> if anonymous.
        /// </summary>
        /// <value>The signature.</value>
        [JsonProperty("signature")]
        public string? Signature { get; private set; }
        
        /// <summary>
        /// Represents the encoded signature.
        /// </summary>
        /// <value>The encoded signature.</value>
        [JsonProperty("encodedSignature")]
        public string? EncodedSignature { get; private set; }
    }
}
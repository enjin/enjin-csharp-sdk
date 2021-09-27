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
    /// Models data about the platform.
    /// </summary>
    [PublicAPI]
    public class Platform
    {
        /// <summary>
        /// Represents the ID of this platform.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public int? Id { get; private set; }
        
        /// <summary>
        /// Represents the name of this platform.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; private set; }
        
        /// <summary>
        /// Represents the current Ethereum network this platform is using.
        /// </summary>
        /// <value>The network.</value>
        [JsonProperty("network")]
        public string? Network { get; private set; }
        
        /// <summary>
        /// Represents the smart contracts used by this platform.
        /// </summary>
        /// <value>The contracts.</value>
        [JsonProperty("contracts")]
        public Contracts? Contracts { get; private set; }
        
        /// <summary>
        /// Represents the notification drivers that this platform is using.
        /// </summary>
        /// <value>The notifications.</value>
        [JsonProperty("notifications")]
        public Notifications? Notifications { get; private set; }
    }
}
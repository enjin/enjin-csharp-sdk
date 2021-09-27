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
    /// Models Pusher channels used by the platform.
    /// </summary>
    [PublicAPI]
    public class PusherChannels
    {
        /// <summary>
        /// Represents the project channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("project")]
        public string? Project { get; private set; }
        
        /// <summary>
        /// Represents the player channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("player")]
        public string? Player { get; private set; }
        
        /// <summary>
        /// Represents the asset channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("asset")]
        public string? Asset { get; private set; }
        
        /// <summary>
        /// Represents the wallet channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("wallet")]
        public string? Wallet { get; private set; }
    }
}
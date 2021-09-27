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
    /// Models Pusher settings for the platform.
    /// </summary>
    [PublicAPI]
    public class Pusher
    {
        /// <summary>
        /// Represents the key for the platform.
        /// </summary>
        /// <value>The key.</value>
        [JsonProperty("key")]
        public string? Key { get; private set; }
        
        /// <summary>
        /// Represents the namespace the platform broadcasts on.
        /// </summary>
        /// <value>The namespace.</value>
        [JsonProperty("namespace")]
        public string? Namespace { get; private set; }
        
        /// <summary>
        /// Represents the Pusher channels the platform broadcasts on.
        /// </summary>
        /// <value>The Pusher channels.</value>
        [JsonProperty("channels")]
        public PusherChannels? Channels { get; private set; }
        
        /// <summary>
        /// Represents the options for Pusher that the platform uses.
        /// </summary>
        /// <value>The Pusher options.</value>
        [JsonProperty("options")]
        public PusherOptions? Options { get; private set; }
    }
}
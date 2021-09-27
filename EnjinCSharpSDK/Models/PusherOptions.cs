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
    /// Models Pusher options used by the platform.
    /// </summary>
    [PublicAPI]
    public class PusherOptions
    {
        /// <summary>
        /// Represents the cluster the platform is in.
        /// </summary>
        /// <value>The cluster.</value>
        [JsonProperty("cluster")]
        public string? Cluster { get; private set; }
        
        /// <summary>
        /// Represents the encryption setting the platform uses.
        /// </summary>
        /// <value>Whether encryption is used or not.</value>
        [JsonProperty("encrypted")]
        public bool? Encrypted { get; private set; }
    }
}
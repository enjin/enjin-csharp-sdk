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
    /// Models the linking information of a <see cref="Player"/>.
    /// </summary>
    [PublicAPI]
    public class LinkingInfo
    {
        /// <summary>
        /// Represents the linking code used to link a wallet to the player this information applies to.
        /// </summary>
        /// <value>The linking code.</value>
        [JsonProperty("code")]
        public string? Code { get; private set; }
        
        /// <summary>
        /// Represents the URL for the QR image to be used to link a wallet to the player this information applies to.
        /// </summary>
        /// <value>The URL for the image.</value>
        [JsonProperty("qr")]
        public string? Qr { get; private set; }
    }
}
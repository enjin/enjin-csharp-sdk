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
    /// Models a successful auth object.
    /// </summary>
    [PublicAPI]
    public class AccessToken
    {
        /// <summary>
        /// Represents the token of the auth object.
        /// </summary>
        /// <value>The token for the auth.</value>
        [JsonProperty("accessToken")]
        public string? Token { get; private set; }
        
        /// <summary>
        /// Represents the number of seconds until the auth expires.
        /// </summary>
        /// <value>The number of seconds until the auth expires.</value>
        [JsonProperty("expiresIn")]
        public long? ExpiresIn { get; private set; }

        /// <summary>
        /// Converts the auth object into a string.
        /// </summary>
        /// <returns>The string format of the auth.</returns>
        public override string ToString()
        {
            return $"{nameof(Token)}: {Token}, {nameof(ExpiresIn)}: {ExpiresIn}";
        }
    }
}
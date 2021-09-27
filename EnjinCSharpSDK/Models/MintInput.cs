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

using Enjin.SDK.ProjectSchema;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a mint input for mint requests.
    /// </summary>
    /// <seealso cref="MintAsset"/>
    [PublicAPI]
    public class MintInput
    {
        [JsonProperty("to")]
        private string? _to;
        [JsonProperty("value")]
        private string? _value;

        /// <summary>
        /// Sets the Ethereum address to mint to.
        /// </summary>
        /// <param name="ethAddress">The address.</param>
        /// <returns>This input for chaining.</returns>
        public MintInput To(string? ethAddress)
        {
            _to = ethAddress;
            return this;
        }

        /// <summary>
        /// Sets the amount of assets to mint.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This input for chaining.</returns>
        public MintInput Value(string? value)
        {
            _value = value;
            return this;
        }
    }
}
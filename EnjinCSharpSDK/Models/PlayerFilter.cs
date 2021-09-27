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
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a filter input for player queries.
    /// </summary>
    /// <seealso cref="Enjin.SDK.ProjectSchema.GetPlayers"/>
    [PublicAPI]
    public class PlayerFilter: Filter<PlayerFilter>
    {
        [JsonProperty("id")]
        private string? _id;
        [JsonProperty("id_in")]
        private List<string>? _idIn;

        /// <summary>
        /// Sets the player ID to filter for.
        /// </summary>
        /// <param name="id">The player ID.</param>
        /// <returns>This filter for chaining.</returns>
        public PlayerFilter Id(string? id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        /// Sets the player IDs to filter for.
        /// </summary>
        /// <param name="ids">The player IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public PlayerFilter IdIn(params string[]? ids)
        {
            _idIn = ids?.ToList();
            return this;
        }
    }
}
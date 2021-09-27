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
    /// Models a pagination input for pagination requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.PaginationArguments"/>
    [PublicAPI]
    public class PaginationOptions
    {
        /// <summary>
        /// Represents the page number to start at for the pagination.
        /// </summary>
        /// <value>The page to start at.</value>
        [JsonProperty("page")]
        public int? Page { get; set; }
        
        /// <summary>
        /// Represents the number of results per page for the pagination.
        /// </summary>
        /// <value>The number of items per page.</value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}
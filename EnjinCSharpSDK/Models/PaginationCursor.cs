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
    /// Models a pagination cursor for queries.
    /// </summary>
    [PublicAPI]
    public class PaginationCursor
    {
        /// <summary>
        /// Represents the total number of items selected for the cursor.
        /// </summary>
        /// <value>The total number of items selected.</value>
        [JsonProperty("total")]
        public int? Total { get; private set; }
        
        /// <summary>
        /// Represents the number of items per page for the cursor.
        /// </summary>
        /// <value>The number of items per page.</value>
        [JsonProperty("perPage")]
        public int? PerPage { get; private set; }
        
        /// <summary>
        /// Represents the current page for the cursor.
        /// </summary>
        /// <value>The current page.</value>
        [JsonProperty("currentPage")]
        public int? CurrentPage { get; private set; }
        
        /// <summary>
        /// Represents whether the cursor has pages.
        /// </summary>
        /// <value>Whether the cursor has pages.</value>
        [JsonProperty("hasPages")]
        public bool? HasPages { get; private set; }
        
        /// <summary>
        /// Represents the first item returned for the cursor.
        /// </summary>
        /// <value>The number of the first item returned.</value>
        [JsonProperty("from")]
        public int? From { get; private set; }
        
        /// <summary>
        /// Represents the last item returned for the cursor.
        /// </summary>
        /// <value>The number of the last item returned.</value>
        [JsonProperty("to")]
        public int? To { get; private set; }
        
        /// <summary>
        /// Represents the last page (number of pages) for the cursor.
        /// </summary>
        /// <value>The last page.</value>
        [JsonProperty("lastPage")]
        public int? LastPage { get; private set; }
        
        /// <summary>
        /// Represents whether there are more pages for the cursor.
        /// </summary>
        /// <value>Whether the cursor has more pages.</value>
        [JsonProperty("hasMorePages")]
        public bool? HasMorePages { get; private set; }
    }
}
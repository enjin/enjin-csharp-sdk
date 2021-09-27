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
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Models the structure of a GraphQL response error.
    /// </summary>
    [PublicAPI]
    public class GraphqlError
    {
        /// <summary>
        /// Represents the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("message")]
        public string? Message { get; private set; }
        
        /// <summary>
        /// Represents the error code.
        /// </summary>
        /// <value>The error code.</value>
        [JsonProperty("code")]
        public int? Code { get; private set; }
        
        /// <summary>
        /// Represents the error locations.
        /// </summary>
        /// <value>The error locations.</value>
        [JsonProperty("locations")]
        public List<Dictionary<string, int>>? Locations { get; private set; }
        
        /// <summary>
        /// Represents the error details.
        /// </summary>
        /// <value>The error details.</value>
        [JsonProperty("details")]
        public string? Details { get; private set; }
    }
}
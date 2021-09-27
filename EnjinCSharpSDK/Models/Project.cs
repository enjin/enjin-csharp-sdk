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
    /// Models a project on the platform.
    /// </summary>
    [PublicAPI]
    public class Project
    {
        /// <summary>
        /// Represents the UUID of this project.
        /// </summary>
        /// <value>The UUID.</value>
        [JsonProperty("uuid")]
        public string? Uuid { get; private set; }
        
        /// <summary>
        /// Represents the name of this project.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; private set; }

        /// <summary>
        /// Represents the description text for this project.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string? Description { get; private set; }
        
        /// <summary>
        /// Represents the URL for the image of this project.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("image")]
        public string? Image { get; private set; }

        /// <summary>
        /// Represents the datetime when this project was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this project was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; private set; }
    }
}
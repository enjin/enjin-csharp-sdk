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
    /// Models the supply models used by the platform.
    /// </summary>
    [PublicAPI]
    public class SupplyModels
    {
        /// <summary>
        /// Represents the fixed model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("fixed")]
        public string? Fixed { get; private set; }
        
        /// <summary>
        /// Represents the settable model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("settable")]
        public string? Settable { get; private set; }
        
        /// <summary>
        /// Represents the infinite model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("infinite")]
        public string? Infinite { get; private set; }
        
        /// <summary>
        /// Represents the collapsing model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("collapsing")]
        public string? Collapsing { get; private set; }
        
        /// <summary>
        /// Represents the annual value model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("annualValue")]
        public string? AnnualValue { get; private set; }
        
        /// <summary>
        /// Represents the annual percentage model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("annualPercentage")]
        public string? AnnualPercentage { get; private set; }
    }
}
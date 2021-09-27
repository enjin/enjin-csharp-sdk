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
    /// Models a gas prices object.
    /// </summary>
    [PublicAPI]
    public class GasPrices
    {
        /// <summary>
        /// The recommended safe gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 30 minutes.
        /// </remarks>
        [JsonProperty("safeLow")]
        public float? SafeLow { get; private set; }
        
        /// <summary>
        /// The recommended average gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 5 minutes.
        /// </remarks>
        [JsonProperty("average")]
        public float? Average { get; private set; }
        
        /// <summary>
        /// The recommended fast gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 2 minutes.
        /// </remarks>
        [JsonProperty("fast")]
        public float? Fast { get; private set; }
        
        /// <summary>
        /// The recommended fastest gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 30 seconds.
        /// </remarks>
        [JsonProperty("fastest")]
        public float? Fastest { get; private set; }
    }
}
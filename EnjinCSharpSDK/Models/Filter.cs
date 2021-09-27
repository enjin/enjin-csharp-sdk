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
    /// Provides implementation of common filter input functionality.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    [PublicAPI]
    public abstract class Filter<T> where T: Filter<T>
    {
        [JsonProperty("and")]
        private List<T>? _and;
        [JsonProperty("or")]
        private List<T>? _or;
        
        /// <summary>
        /// Sets the filter to include other filters to intersect with.
        /// </summary>
        /// <param name="others">The other filters.</param>
        /// <returns>This filter for chaining.</returns>
        public T And(params T[]? others)
        {
            _and = others?.ToList();
            return (T) this;
        }
        
        /// <summary>
        /// Sets the filter to include other filters to union with.
        /// </summary>
        /// <param name="others">The other filters.</param>
        /// <returns>This filter for chaining.</returns>
        public T Or(params T[]? others)
        {
            _or = others?.ToList();
            return (T) this;
        }
    }
}
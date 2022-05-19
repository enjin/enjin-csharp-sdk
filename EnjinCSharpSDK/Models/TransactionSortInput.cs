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
    /// Models sorting input for transactions.
    /// </summary>
    [PublicAPI]
    public class TransactionSortInput
    {
        [JsonProperty("field")]
        private TransactionField? _field;

        [JsonProperty("direction")]
        private SortDirection? _direction;

        /// <summary>
        /// Sets the field to sort by.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>This input for chaining.</returns>
        public TransactionSortInput Field(TransactionField? field)
        {
            _field = field;
            return this;
        }

        /// <summary>
        /// Sets the direction to sort by.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>This input for chaining.</returns>
        public TransactionSortInput Direction(SortDirection? direction)
        {
            _direction = direction;
            return this;
        }
    }
}
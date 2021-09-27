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
using Enjin.SDK.Models;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Models the body of a GraphQL response.
    /// </summary>
    /// <typeparam name="T">The model of the data field.</typeparam>
    [PublicAPI]
    public class GraphqlResponse<T>
    {
        /// <summary>
        /// Represents the result of this response.
        /// </summary>
        /// <value>The result.</value>
        /// <remarks>
        /// For responses wrapping a value type or non-nullable type, consider checking
        /// <see cref="GraphqlResponse{T}.IsSuccess"/> if the result equals the types default value.
        /// </remarks>
        public T Result { get; private set; } = default!;
        
        /// <summary>
        /// Represents the errors of this response if any exist.
        /// </summary>
        /// <value>The errors.</value>
        public List<GraphqlError>? Errors { get; private set; }
        
        /// <summary>
        /// Represents the pagination cursor.
        /// </summary>
        /// <value>The cursor.</value>
        public PaginationCursor? Cursor { get; private set; }

        /// <summary>
        /// Represents whether the response has errors.
        /// </summary>
        /// <value>Whether the response has errors.</value>
        public bool HasErrors => Errors != null && Errors.Count != 0;

        /// <summary>
        /// Represents whether the response has a result or not.
        /// </summary>
        /// <value>Whether the result is <c>null</c>.</value>
        /// <remarks>
        /// For responses wrapping a value type or non-nullable type, consider checking
        /// <see cref="GraphqlResponse{T}.IsSuccess"/> instead.
        /// </remarks>
        public bool IsEmpty => Result == null;
        
        /// <summary>
        /// Represents whether the response is paginated or not.
        /// </summary>
        /// <value>Whether the response is paginated.</value>
        public bool IsPaginated => Cursor != null;

        /// <summary>
        /// Represents whether the response is successful.
        /// </summary>
        /// <value>Whether the response is successful.</value>
        /// <remarks>
        /// A response is considered successful if it has no errors and is not empty.
        /// </remarks>
        public bool IsSuccess => !(IsEmpty || HasErrors);
        
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="data">The deserialized response data.</param>
        /// <param name="errors">The serialized errors.</param>
        [JsonConstructor]
        public GraphqlResponse(GraphqlData<T>? data, List<GraphqlError>? errors)
        {
            if (data != null)
            {
                Result = data.Result;
                Cursor = data.Cursor;
            }

            Errors = errors;
        }

        /// <summary>
        /// Returns the string representative of this response. Will provide either the result or the errors if errors
        /// are present.
        /// </summary>
        /// <returns>The string representing the response.</returns>
        public override string ToString()
        {
            return HasErrors ? $"{nameof(Errors)}: {Errors}" : $"{nameof(Result)}: {Result}";
        }
    }

    /// <summary>
    /// Container for GraphQL data.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    [UsedImplicitly]
    public class GraphqlData<T>
    {
        private const string ItemsKey = "items";
        private const string CursorKey = "cursor";

        /// <summary>
        /// Represents the deserialized GraphQL result.
        /// </summary>
        /// <value>The result.</value>
        public T Result { get; private set; } = default!;
        
        /// <summary>
        /// Represents the deserialized cursor.
        /// </summary>
        /// <value>The cursor.</value>
        public PaginationCursor? Cursor { get; private set; }

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="result">The serialized result.</param>
        [JsonConstructor]
        public GraphqlData(JToken result)
        {
            ProcessJsonResult(result);
        }
        
        /// <summary>
        /// Returns a string that represents the result in the data.
        /// </summary>
        /// <returns>The string representing the result.</returns>
        public override string ToString()
        {
            return $"{nameof(Result)}: {Result}";
        }

        private void ProcessJsonResult(JToken result)
        {
            if (result.Type == JTokenType.Object)
                ProcessResultObject((JObject) result);
            else
            {
                Result = result.ToObject<T>()!;
            }
        }

        private void ProcessResultObject(JObject result)
        {
            var isPaginated = result.ContainsKey(ItemsKey);
            if (isPaginated)
            {
                var items = result[ItemsKey];
                if (items is {Type: JTokenType.Array})
                {
                    Result = items.ToObject<T>()!;
                }
                
                if (result.ContainsKey(CursorKey))
                    Cursor = result[CursorKey]?.ToObject<PaginationCursor>();
            }
            else
            {
                Result = result.ToObject<T>()!;
            }
        }
    }
}
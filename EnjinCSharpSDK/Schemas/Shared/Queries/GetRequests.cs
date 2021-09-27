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

using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting transactions on the platform.
    /// </summary>
    /// <seealso cref="Request"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetRequests : GraphqlRequest<GetRequests>, ITransactionFragmentArguments<GetRequests>, IPaginationArguments<GetRequests>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetRequests() : base("enjin.sdk.shared.GetRequests")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetRequests Filter(TransactionFilter? filter)
        {
            return SetVariable("filter", filter);
        }

        /// <summary>
        /// Sets the request to sort the results by the specified options.
        /// </summary>
        /// <param name="sort">The sort options.</param>
        /// <returns>This request for chaining.</returns>
        public GetRequests Sort(TransactionSort? sort)
        {
            return SetVariable("sort", sort);
        }
    }
}
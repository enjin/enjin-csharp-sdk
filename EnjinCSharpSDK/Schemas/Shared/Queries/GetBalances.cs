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
    /// Request for getting balances on the platform.
    /// </summary>
    /// <seealso cref="Balance"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetBalances : GraphqlRequest<GetBalances>, IBalanceFragmentArguments<GetBalances>, IPaginationArguments<GetBalances>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetBalances() : base("enjin.sdk.shared.GetBalances")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetBalances Filter(BalanceFilter? filter)
        {
            return SetVariable("filter", filter);
        }
    }
}
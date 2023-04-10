// Copyright 2023 Enjin Pte. Ltd.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting balances from different projects on the platform.
    /// </summary>
    /// <seealso cref="Balance"/>
    /// <seealso cref="SharedSchema"/>
    [PublicAPI]
    public class GetBalancesFromProjects : GraphqlRequest<GetBalancesFromProjects>,
                                           IBalanceFragmentArguments<GetBalancesFromProjects>,
                                           IPaginationArguments<GetBalancesFromProjects>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetBalancesFromProjects() : base("enjin.sdk.shared.GetBalancesFromProjects")
        {
        }

        /// <summary>
        /// Sets the project UUIDs.
        /// </summary>
        /// <param name="projects">The UUIDs.</param>
        /// <returns>This request for chaining.</returns>
        public GetBalancesFromProjects Projects(params string[]? projects)
        {
            return SetVariable("projects", projects);
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetBalancesFromProjects Filter(BalanceFilter? filter)
        {
            return SetVariable("filter", filter);
        }
    }
}
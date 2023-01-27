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
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for getting assets from different projects on the platform.
    /// </summary>
    /// <seealso cref="Asset"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetAssetsFromProject : GraphqlRequest<GetAssetsFromProject>,
                                        IAssetFragmentArguments<GetAssetsFromProject>,
                                        IPaginationArguments<GetAssetsFromProject>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetAssetsFromProject() : base("enjin.sdk.project.GetAssetsFromProject")
        {
        }

        /// <summary>
        /// Sets the project UUIDs.
        /// </summary>
        /// <param name="projects">The UUIDs.</param>
        /// <returns>This request for chaining.</returns>
        public GetAssetsFromProject Projects(params string[]? projects)
        {
            return SetVariable("projects", projects);
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetAssetsFromProject Filter(AssetFilter? filter)
        {
            return SetVariable("filter", filter);
        }

        /// <summary>
        /// Sets the request to sort the results by the specified options.
        /// </summary>
        /// <param name="sort">The sort input.</param>
        /// <returns>This request for chaining.</returns>
        public GetAssetsFromProject Sort(AssetSortInput? sort)
        {
            return SetVariable("sort", sort);
        }
    }
}
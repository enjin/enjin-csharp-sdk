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
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting a project on the platform.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Project"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetProject : GraphqlRequest<GetProject>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetProject() : base("enjin.sdk.shared.GetProject")
        {
        }

        /// <summary>
        /// Sets the project ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetProject Id(int? id)
        {
            return SetVariable("id", id);
        }

        /// <summary>
        /// Sets the project name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>This request for chaining.</returns>
        public GetProject Name(string? name)
        {
            return SetVariable("name", name);
        }
    }
}
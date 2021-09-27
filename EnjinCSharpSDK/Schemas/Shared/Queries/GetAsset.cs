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
    /// Request for getting a asset on the platform.
    /// </summary>
    /// <seealso cref="Asset"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetAsset : GraphqlRequest<GetAsset>, IAssetFragmentArguments<GetAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetAsset() : base("enjin.sdk.shared.GetAsset")
        {
        }

        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetAsset Id(string? id)
        {
            return SetVariable("id", id);
        }
    }
}
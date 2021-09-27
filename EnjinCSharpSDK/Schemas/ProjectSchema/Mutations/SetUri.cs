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

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to set the URI for the metadata of an asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetUri : GraphqlRequest<SetUri>, IProjectTransactionRequestArguments<SetUri>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetUri() : base("enjin.sdk.project.SetUri")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri AssetIndex(string? assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }
        
        /// <summary>
        /// Sets the new URI for the asset's metadata.
        /// </summary>
        /// <param name="uri">The new URI.</param>
        /// <returns>This request for chaining.</returns>
        public SetUri Uri(string? uri)
        {
            return SetVariable("uri", uri);
        }
    }
}
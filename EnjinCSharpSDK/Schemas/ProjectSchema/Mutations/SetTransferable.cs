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

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting if a asset may be transferred.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetTransferable : GraphqlRequest<SetTransferable>, IProjectTransactionRequestArguments<SetTransferable>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetTransferable() : base("enjin.sdk.project.SetTransferable")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable AssetIndex(string? assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }
        
        /// <summary>
        /// Sets the new transfer mode.
        /// </summary>
        /// <param name="transferable">The new mode.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferable Transferable(AssetTransferable? transferable)
        {
            return SetVariable("transferable", transferable);
        }
    }
}
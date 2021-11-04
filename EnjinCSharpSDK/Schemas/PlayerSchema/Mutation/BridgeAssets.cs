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
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for bridging multiple indices of an NFT in a single transaction.
    /// </summary>
    /// <seealso cref="BridgeAsset"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class BridgeAssets : GraphqlRequest<BridgeAssets>, ITransactionFragmentArguments<BridgeAssets>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public BridgeAssets() : base("enjin.sdk.player.BridgeAssets")
        {
        }

        /// <summary>
        /// Sets the ID of the asset to bridge.
        /// </summary>
        /// <param name="assetId">The asset ID.</param>
        /// <returns>This request for chaining.</returns>
        public BridgeAssets AssetId(string? assetId)
        {
            SetVariable("assetId", assetId);
            return this;
        }

        /// <summary>
        /// Sets the indices to bridge.
        /// </summary>
        /// <param name="assetIndices">The asset indices.</param>
        /// <returns>This request for chaining.</returns>
        public BridgeAssets AssetIndices(params string[]? assetIndices)
        {
            SetVariable("assetIndices", assetIndices);
            return this;
        }
    }
}
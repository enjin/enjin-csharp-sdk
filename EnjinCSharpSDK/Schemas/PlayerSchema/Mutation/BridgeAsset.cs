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
    /// Request for bridging an asset.
    /// </summary>
    /// <seealso cref="BridgeAssets"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class BridgeAsset : GraphqlRequest<BridgeAsset>, ITransactionFragmentArguments<BridgeAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public BridgeAsset() : base("enjin.sdk.player.BridgeAsset")
        {
        }

        /// <summary>
        /// Sets the ID of the asset to bridge.
        /// </summary>
        /// <param name="assetId">The asset ID.</param>
        /// <returns>This request for chaining.</returns>
        public BridgeAsset AssetId(string? assetId)
        {
            SetVariable("assetId", assetId);
            return this;
        }

        /// <summary>
        /// Sets the index of the asset to bridge if the asset is an NFT.
        /// </summary>
        /// <param name="assetIndex">The asset index.</param>
        /// <returns>This request for chaining.</returns>
        public BridgeAsset AssetIndex(string? assetIndex)
        {
            SetVariable("assetIndex", assetIndex);
            return this;
        }

        /// <summary>
        /// Sets the amount to bridge.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This request for chaining.</returns>
        public BridgeAsset Value(string? value)
        {
            return this;
        }
    }
}
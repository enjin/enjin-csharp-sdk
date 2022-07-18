﻿/* Copyright 2021 Enjin Pte. Ltd.
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
    /// Request for claiming assets on the bridge.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class BridgeClaimAsset : GraphqlRequest<BridgeClaimAsset>,
                                    ITransactionRequestArguments<BridgeClaimAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public BridgeClaimAsset() : base("enjin.sdk.project.BridgeClaimAsset")
        {
        }

        /// <summary>
        /// Sets which assets to filter for by their ID.
        /// </summary>
        /// <param name="assetId">The asset IDs to filter for.</param>
        /// <returns>This request for chaining.</returns>
        public BridgeClaimAsset AssetId(string? assetId)
        {
            SetVariable("assetId", assetId);
            return this;
        }
    }
}
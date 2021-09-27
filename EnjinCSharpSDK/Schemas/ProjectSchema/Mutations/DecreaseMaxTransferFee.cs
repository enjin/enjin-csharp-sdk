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
    /// Request for setting an asset's max transfer fee to a lower value.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class DecreaseMaxTransferFee : GraphqlRequest<DecreaseMaxTransferFee>, IProjectTransactionRequestArguments<DecreaseMaxTransferFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public DecreaseMaxTransferFee() : base("enjin.sdk.project.DecreaseMaxTransferFee")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxTransferFee AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the new max transfer in Wei.
        /// </summary>
        /// <param name="maxTransferFee">The new fee.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxTransferFee MaxTransferFee(int? maxTransferFee)
        {
            return SetVariable("maxTransferFee", maxTransferFee);
        }
    }
}
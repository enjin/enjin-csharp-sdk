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
    /// Request for setting an asset's max melt fee to a lower value.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class DecreaseMaxMeltFee : GraphqlRequest<DecreaseMaxMeltFee>, IProjectTransactionRequestArguments<DecreaseMaxMeltFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public DecreaseMaxMeltFee() : base("enjin.sdk.project.DecreaseMaxMeltFee")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxMeltFee AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the new max melt fee for the asset.
        /// </summary>
        /// <param name="maxMeltFee">The new ratio.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The ratio is in the range 0-5000 to allow fractional ratios, e.g. 1 = 0.01%, 5000 = 50%, ect...
        /// </remarks>
        public DecreaseMaxMeltFee MaxMeltFee(int? maxMeltFee)
        {
            return SetVariable("maxMeltFee", maxMeltFee);
        }
    }
}
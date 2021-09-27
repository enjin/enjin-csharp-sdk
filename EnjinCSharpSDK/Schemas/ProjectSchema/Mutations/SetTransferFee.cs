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
    /// Request for setting the transfer fee of a asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetTransferFee : GraphqlRequest<SetTransferFee>, IProjectTransactionRequestArguments<SetTransferFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetTransferFee() : base("enjin.sdk.project.SetTransferFee")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the new transfer fee value in Wei.
        /// </summary>
        /// <param name="transferFee">The new transfer fee.</param>
        /// <returns>This request for chaining.</returns>
        public SetTransferFee TransferFee(string? transferFee)
        {
            return SetVariable("transferFee", transferFee);
        }
    }
}
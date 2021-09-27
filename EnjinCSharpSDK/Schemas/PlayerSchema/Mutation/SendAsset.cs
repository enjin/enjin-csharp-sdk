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
    /// Request for sending a asset.
    /// </summary>
    /// <seealso cref="AdvancedSendAsset"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class SendAsset : GraphqlRequest<SendAsset>, ITransactionFragmentArguments<SendAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SendAsset() : base("enjin.sdk.player.SendAsset")
        {
        }

        /// <summary>
        /// Sets the wallet address of the recipient.
        /// </summary>
        /// <param name="recipientAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset RecipientAddress(string? recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }

        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset AssetIndex(string? assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }

        /// <summary>
        /// Sets the amount to send.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset Value(string? value)
        {
            return SetVariable("value", value);
        }

        /// <summary>
        /// Sets the data to forward with the transaction.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset Data(string? data)
        {
            return SetVariable("data", data);
        }
    }
}
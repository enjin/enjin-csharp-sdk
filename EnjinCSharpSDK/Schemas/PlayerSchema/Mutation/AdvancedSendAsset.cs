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
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for sending one or more assets in a single transaction.
    /// </summary>
    /// <seealso cref="SendAsset"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class AdvancedSendAsset : GraphqlRequest<AdvancedSendAsset>, ITransactionFragmentArguments<AdvancedSendAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public AdvancedSendAsset() : base("enjin.sdk.player.AdvancedSendAsset")
        {
        }

        /// <summary>
        /// Sets the different transfers to perform.
        /// </summary>
        /// <param name="transfers">The transfers.</param>
        /// <returns>This request for chaining.</returns>
        public AdvancedSendAsset Transfers(params TransferInput[]? transfers)
        {
            return SetVariable("transfers", transfers);
        }

        /// <summary>
        /// Sets the data to forward with the transaction.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>This request for chaining.</returns>
        public AdvancedSendAsset Data(string? data)
        {
            return SetVariable("data", data);
        }
    }
}
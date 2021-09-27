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
    /// Request for creating a trade between two wallets.
    /// </summary>
    /// <seealso cref="CompleteTrade"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class CreateTrade : GraphqlRequest<CreateTrade>, IProjectTransactionRequestArguments<CreateTrade>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CreateTrade() : base("enjin.sdk.project.CreateTrade")
        {
        }

        /// <summary>
        /// Sets the assets the sender is asking for.
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade AskingAssets(params Trade[]? assets)
        {
            return SetVariable("askingAssets", assets);
        }

        /// <summary>
        /// Sets the assets to be offered by the sender.
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade OfferingAssets(params Trade[]? assets)
        {
            return SetVariable("offeringAssets", assets);
        }

        /// <summary>
        /// Sets the wallet address of the recipient.
        /// </summary>
        /// <param name="recipientAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade RecipientAddress(string? recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }
    }
}
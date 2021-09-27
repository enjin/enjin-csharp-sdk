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

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for getting player wallets.
    /// </summary>
    /// <seealso cref="Wallet"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetWallets : GraphqlRequest<GetWallets>,
                              IWalletFragmentArguments<GetWallets>,
                              IPaginationArguments<GetWallets>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetWallets() : base("enjin.sdk.project.GetWallets")
        {
        }

        /// <summary>
        /// Sets the user IDs owning the wallets to get.
        /// </summary>
        /// <param name="userIds">The user IDs.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallets UserIds(params string[]? userIds)
        {
            return SetVariable("userIds", userIds);
        }

        /// <summary>
        /// Sets the Ethereum addresses of the wallets to get.
        /// </summary>
        /// <param name="ethAddresses">The addresses.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallets EthAddresses(params string[]? ethAddresses)
        {
            return SetVariable("ethAddresses", ethAddresses);
        }
    }
}
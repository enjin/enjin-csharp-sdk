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
    /// Request for getting a player's wallet.
    /// </summary>
    /// <seealso cref="Wallet"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetWallet : GraphqlRequest<GetWallet>, IWalletFragmentArguments<GetWallet>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetWallet() : base("enjin.sdk.project.GetWallet")
        {
        }

        /// <summary>
        /// Sets the user ID owning the wallet to get.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallet UserId(string? userId)
        {
            return SetVariable("userId", userId);
        }
        
        /// <summary>
        /// Sets the Ethereum address of the wallet to get.
        /// </summary>
        /// <param name="ethAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallet EthAddress(string? ethAddress)
        {
            return SetVariable("ethAddress", ethAddress);
        }
    }
}
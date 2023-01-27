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

using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using Enjin.SDK.Utils;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Class for sending requests in the project schema.
    /// </summary>
    [PublicAPI]
    public class ProjectSchema : SharedSchema, IProjectSchema
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        public ProjectSchema(ClientMiddleware middleware, LoggerProvider? loggerProvider) :
            base(middleware, "project", loggerProvider)
        {
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> AdvancedSendAsset(AdvancedSendAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> ApproveEnj(ApproveEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> ApproveMaxEnj(ApproveMaxEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request)
        {
            return SendRequest<AccessToken>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request)
        {
            return SendRequest<AccessToken>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> BridgeAsset(BridgeAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> BridgeAssets(BridgeAssets request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> BridgeClaimAsset(BridgeClaimAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> CompleteTrade(CompleteTrade request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> CreateAsset(CreateAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request)
        {
            return SendRequest<AccessToken>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> CreateTrade(CreateTrade request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> DecreaseMaxMeltFee(DecreaseMaxMeltFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> DecreaseMaxTransferFee(DecreaseMaxTransferFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool?>> DeletePlayer(DeletePlayer request)
        {
            return SendRequest<bool?>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Asset>>> GetAssetsFromProject(GetAssetsFromProject request)
        {
            return SendRequest<List<Asset>>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest<Player>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request)
        {
            return SendRequest<List<Player>>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Wallet>> GetWallet(GetWallet request)
        {
            return SendRequest<Wallet>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Wallet>>> GetWallets(GetWallets request)
        {
            return SendRequest<List<Wallet>>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool?>> InvalidateAssetMetadata(InvalidateAssetMetadata request)
        {
            return SendRequest<bool?>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> MeltAsset(MeltAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> Message(Message request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> MintAsset(MintAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> ReleaseReserve(ReleaseReserve request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> ResetEnjApproval(ResetEnjApproval request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SendEnj(SendEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SendAsset(SendAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SetApprovalForAll(SetApprovalForAll request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SetMeltFee(SetMeltFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SetTransferable(SetTransferable request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SetTransferFee(SetTransferFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SetUri(SetUri request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> SetWhitelisted(SetWhitelisted request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool?>> UnlinkWallet(UnlinkWallet request)
        {
            return SendRequest<bool?>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Transaction>> UpdateName(UpdateName request)
        {
            return TransactionRequest(request);
        }
    }
}
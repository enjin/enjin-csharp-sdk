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
        private const string SCHEMA = "project";

        internal readonly IPlayerService PlayerService;
        internal readonly IWalletService WalletService;

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        public ProjectSchema(TrustedPlatformMiddleware middleware, LoggerProvider loggerProvider) :
            base(middleware, SCHEMA, loggerProvider)
        {
            PlayerService = CreateService<IPlayerService>();
            WalletService = CreateService<IWalletService>();
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> AdvancedSendAsset(AdvancedSendAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ApproveEnj(ApproveEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ApproveMaxEnj(ApproveMaxEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request)
        {
            return SendRequest(PlayerService.Auth(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request)
        {
            return SendRequest(ProjectService.Auth(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> CompleteTrade(CompleteTrade request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> CreateAsset(CreateAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request)
        {
            return SendRequest(PlayerService.Auth(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> CreateTrade(CreateTrade request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> DecreaseMaxMeltFee(DecreaseMaxMeltFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> DecreaseMaxTransferFee(DecreaseMaxTransferFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest(PlayerService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request)
        {
            return SendRequest(PlayerService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Wallet>> GetWallet(GetWallet request)
        {
            return SendRequest(WalletService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Wallet>>> GetWallets(GetWallets request)
        {
            return SendRequest(WalletService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> InvalidateAssetMetadata(InvalidateAssetMetadata request)
        {
            return SendRequest(AssetService.Delete(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> MeltAsset(MeltAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> Message(Message request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> MintAsset(MintAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ReleaseReserve(ReleaseReserve request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> ResetEnjApproval(ResetEnjApproval request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SendEnj(SendEnj request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SendAsset(SendAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetApprovalForAll(SetApprovalForAll request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetMeltFee(SetMeltFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetTransferable(SetTransferable request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetTransferFee(SetTransferFee request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetUri(SetUri request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> SetWhitelisted(SetWhitelisted request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }
    }
}
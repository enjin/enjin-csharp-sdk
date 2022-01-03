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

using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using Enjin.SDK.Utils;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Class for sending requests in the player schema.
    /// </summary>
    [PublicAPI]
    public class PlayerSchema : SharedSchema, IPlayerSchema
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        public PlayerSchema(TrustedPlatformMiddleware middleware, LoggerProvider? loggerProvider) :
            base(middleware, "player", loggerProvider)
        {
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
        public Task<GraphqlResponse<Request>> BridgeAsset(BridgeAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> BridgeAssets(BridgeAssets request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> BridgeClaimAsset(BridgeClaimAsset request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest<Player>(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Wallet>> GetWallet(GetWallet request)
        {
            return SendRequest<Wallet>(request);
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
        public Task<GraphqlResponse<bool?>> UnlinkWallet(UnlinkWallet request)
        {
            return SendRequest<bool?>(request);
        }
    }
}
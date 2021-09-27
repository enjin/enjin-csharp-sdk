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
using Enjin.SDK.Utils;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Class for sending requests shared across schemas.
    /// </summary>
    [PublicAPI]
    public class SharedSchema : BaseSchema, ISharedSchema
    {
        internal readonly IAssetService AssetService;
        internal readonly IProjectService ProjectService;
        internal readonly IBalanceService BalanceService;
        internal readonly IPlatformService PlatformService;
        internal readonly IRequestService RequestService;

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        protected SharedSchema(TrustedPlatformMiddleware middleware, string schema, LoggerProvider loggerProvider) :
            base(middleware, schema, loggerProvider)
        {
            AssetService = CreateService<IAssetService>();
            ProjectService = CreateService<IProjectService>();
            BalanceService = CreateService<IBalanceService>();
            PlatformService = CreateService<IPlatformService>();
            RequestService = CreateService<IRequestService>();
        }
        
        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> CancelTransaction(CancelTransaction request)
        {
            return SendRequest(RequestService.Delete(Schema, CreateRequestBody(request)));
        }
        
        /// <inheritdoc/>
        public Task<GraphqlResponse<Asset>> GetAsset(GetAsset request)
        {
            return SendRequest(AssetService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Asset>>> GetAssets(GetAssets request)
        {
            return SendRequest(AssetService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Balance>>> GetBalances(GetBalances request)
        {
            return SendRequest(BalanceService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<GasPrices>> GetGasPrices(GetGasPrices request)
        {
            return SendRequest(PlatformService.GetGasPrices(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Platform>> GetPlatform(GetPlatform request)
        {
            return SendRequest(PlatformService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Project>> GetProject(GetProject request)
        {
            return SendRequest(ProjectService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Request>> GetRequest(GetRequest request)
        {
            return TransactionRequest(request);
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<List<Request>>> GetRequests(GetRequests request)
        {
            return SendRequest(RequestService.GetMany(Schema, CreateRequestBody(request)));
        }

        /// <summary>
        /// Helper method for sending transaction requests.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        protected Task<GraphqlResponse<Request>> TransactionRequest(IGraphqlRequest request)
        {
            return SendRequest(RequestService.GetOne(Schema, CreateRequestBody(request)));
        }
    }
}
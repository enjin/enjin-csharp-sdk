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
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Interface for shared schema implementation.
    /// </summary>
    [PublicAPI]
    public interface ISharedSchema
    {
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.CancelTransaction"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> CancelTransaction(CancelTransaction request);

        /// <summary>
        /// Creates a task and sends the <see cref="Shared.GetAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Asset>> GetAsset(GetAsset request);

        /// <summary>
        /// Creates a task and sends the <see cref="Shared.GetAssets"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Asset>>> GetAssets(GetAssets request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.GetBalances"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Balance>>> GetBalances(GetBalances request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.GetGasPrices"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<GasPrices>> GetGasPrices(GetGasPrices request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.GetPlatform"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Platform>> GetPlatform(GetPlatform request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.GetProject"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Project>> GetProject(GetProject request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.GetRequest"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> GetRequest(GetRequest request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.GetRequests"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Request>>> GetRequests(GetRequests request);
    }
}
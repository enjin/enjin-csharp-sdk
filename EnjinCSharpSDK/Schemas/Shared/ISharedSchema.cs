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
        /// Creates a task and sends the <see cref="Shared.AdvancedSendAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> AdvancedSendAsset(AdvancedSendAsset request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.ApproveEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ApproveEnj(ApproveEnj request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.ApproveMaxEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ApproveMaxEnj(ApproveMaxEnj request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.CancelTransaction"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> CancelTransaction(CancelTransaction request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.CompleteTrade"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CompleteTrade(CompleteTrade request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.CreateTrade"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CreateTrade(CreateTrade request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Shared.MeltAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> MeltAsset(MeltAsset request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.Message"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> Message(Message request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.ResetEnjApproval"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ResetEnjApproval(ResetEnjApproval request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.SendEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SendEnj(SendEnj request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Shared.SendAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SendAsset(SendAsset request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.Shared.SetApprovalForAll"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetApprovalForAll(SetApprovalForAll request);
    }
}
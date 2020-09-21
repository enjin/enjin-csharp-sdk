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
        /// Creates a task and sends the <see cref="GetBalances"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Balance>>> GetBalances(GetBalances request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetGasPrices"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<GasPrices>> GetGasPrices(GetGasPrices request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetPlatform"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Platform>> GetPlatform(GetPlatform request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="GetProject"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Project>> GetProject(GetProject request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetRequest"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> GetRequest(GetRequest request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetRequests"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Request>>> GetRequests(GetRequests request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Token>> GetToken(GetToken request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetTokens"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Token>>> GetTokens(GetTokens request);

        /// <summary>
        /// Creates a task and sends the <see cref="AdvancedSendToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> AdvancedSendToken(AdvancedSendToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="ApproveEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ApproveEnj(ApproveEnj request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="ApproveMaxEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ApproveMaxEnj(ApproveMaxEnj request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="CompleteTrade"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CompleteTrade(CompleteTrade request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="CreateTrade"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CreateTrade(CreateTrade request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="MeltToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> MeltToken(MeltToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Message"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> Message(Message request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="ResetEnjApproval"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ResetEnjApproval(ResetEnjApproval request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SendEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SendEnj(SendEnj request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SendToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SendToken(SendToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SetApprovalForAll"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetApprovalForAll(SetApprovalForAll request);
    }
}
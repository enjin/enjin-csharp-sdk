using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Interface for player schema implementation.
    /// </summary>
    [PublicAPI]
    public interface IPlayerSchema : ISharedSchema
    {
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.AdvancedSendAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> AdvancedSendAsset(AdvancedSendAsset request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.ApproveEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ApproveEnj(ApproveEnj request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.ApproveMaxEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ApproveMaxEnj(ApproveMaxEnj request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.CompleteTrade"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CompleteTrade(CompleteTrade request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.CreateTrade"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CreateTrade(CreateTrade request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.GetPlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.GetWallet"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GraphqlResponse<Wallet>> GetWallet(GetWallet request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.MeltAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> MeltAsset(MeltAsset request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.Message"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> Message(Message request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.ResetEnjApproval"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ResetEnjApproval(ResetEnjApproval request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.SendAsset"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SendAsset(SendAsset request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.SendEnj"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SendEnj(SendEnj request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.SetApprovalForAll"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetApprovalForAll(SetApprovalForAll request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.UnlinkWallet"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request);
    }
}
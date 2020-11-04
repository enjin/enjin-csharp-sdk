using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Interface for project schema implementation.
    /// </summary>
    [PublicAPI]
    public interface IProjectSchema : ISharedSchema
    {
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.AuthPlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.AuthProject"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.GetPlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.GetPlayers"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.GetWallet"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Wallet>> GetWallet(GetWallet request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.GetWallets"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Wallet>>> GetWallets(GetWallets request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.CreatePlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.CreateToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CreateToken(CreateToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.DecreaseMaxMeltFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> DecreaseMaxMeltFee(DecreaseMaxMeltFee request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.DecreaseMaxTransferFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> DecreaseMaxTransferFee(DecreaseMaxTransferFee request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.DeletePlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.InvalidateTokenMetadata"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> InvalidateTokenMetadata(InvalidateTokenMetadata request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.MintToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> MintToken(MintToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.ReleaseReserve"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ReleaseReserve(ReleaseReserve request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.SetMeltFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetMeltFee(SetMeltFee request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.SetTransferable"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetTransferable(SetTransferable request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.SetTransferFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetTransferFee(SetTransferFee request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.SetUri"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetUri(SetUri request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.SetWhitelisted"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetWhitelisted(SetWhitelisted request);

        /// <summary>
        /// Creates a task and sends the <see cref="Enjin.SDK.ProjectSchema.UnlinkWallet"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request);
    }
}
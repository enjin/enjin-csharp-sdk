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
        /// Creates a task and sends the <see cref="AuthPlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="AuthProject"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetPlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request);

        /// <summary>
        /// Creates a task and sends the <see cref="GetPlayers"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="CreatePlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request);

        /// <summary>
        /// Creates a task and sends the <see cref="CreateToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> CreateToken(CreateToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="DecreaseMaxMeltFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> DecreaseMaxMeltFee(DecreaseMaxMeltFee request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="DecreaseMaxTransferFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> DecreaseMaxTransferFee(DecreaseMaxTransferFee request);

        /// <summary>
        /// Creates a task and sends the <see cref="DeletePlayer"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="InvalidateTokenMetadata"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> InvalidateTokenMetadata(InvalidateTokenMetadata request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="MintToken"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> MintToken(MintToken request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="ReleaseReserve"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> ReleaseReserve(ReleaseReserve request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SetMeltFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetMeltFee(SetMeltFee request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SetTransferable"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetTransferable(SetTransferable request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SetTransferFee"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetTransferFee(SetTransferFee request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SetUri"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetUri(SetUri request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="SetWhitelisted"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> SetWhitelisted(SetWhitelisted request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="UnlinkWallet"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request);
        
        /// <summary>
        /// Creates a task and sends the <see cref="UpdateName"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<Request>> UpdateName(UpdateName request);
    }
}
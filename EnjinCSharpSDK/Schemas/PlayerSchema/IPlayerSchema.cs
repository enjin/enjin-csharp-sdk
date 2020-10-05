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
        /// Creates a task and sends the <see cref="Enjin.SDK.PlayerSchema.UnlinkWallet"/> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The task.</returns>
        Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request);
    }
}
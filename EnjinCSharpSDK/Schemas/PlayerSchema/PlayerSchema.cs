using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Class for sending requests in the player schema.
    /// </summary>
    [PublicAPI]
    public class PlayerSchema : SharedSchema, IPlayerSchema
    {
        private const string SCHEMA = "player";
        
        internal readonly IPlayerService PlayerService;
        
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        public PlayerSchema(TrustedPlatformMiddleware middleware) : base(middleware, SCHEMA)
        {
            PlayerService = CreateService<IPlayerService>();
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest(PlayerService.GetOne(Schema, CreateRequestBody(request)));
        }

        /// <inheritdoc/>
        public Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }
    }
}
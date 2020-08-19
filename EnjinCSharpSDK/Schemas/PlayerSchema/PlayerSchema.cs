using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public class PlayerSchema : SharedSchema, IPlayerSchema
    {
        private const string SCHEMA = "player";
        
        internal readonly IPlayerService PlayerService;
        
        public PlayerSchema(TrustedPlatformMiddleware middleware) : base(middleware, SCHEMA)
        {
            PlayerService = CreateService<IPlayerService>();
        }

        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest(PlayerService.GetOne(Schema, CreateRequestBody(request)));
        }

        public Task<GraphqlResponse<bool>> UnlinkWallet(UnlinkWallet request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }
    }
}
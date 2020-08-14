using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class ProjectSchema : SharedSchema, IProjectSchema
    {
        private const string SCHEMA = "app";
        
        internal readonly IPlayerService PlayerService;
        
        public ProjectSchema(TrustedPlatformMiddleware middleware) : base(middleware, SCHEMA)
        {
            PlayerService = CreateService<IPlayerService>();
        }

        public Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request)
        {
            return SendRequest(ProjectService.Auth(Schema, CreateRequestBody(request)));
        }

        public Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request)
        {
            return SendRequest(PlayerService.Auth(Schema, CreateRequestBody(request)));
        }

        public Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request)
        {
            return SendRequest(PlayerService.Auth(Schema, CreateRequestBody(request)));
        }

        public Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request)
        {
            return SendRequest(PlayerService.GetOne(Schema, CreateRequestBody(request)));
        }

        public Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request)
        {
            return SendRequest(PlayerService.GetMany(Schema, CreateRequestBody(request)));
        }

        public Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request)
        {
            return SendRequest(PlayerService.Delete(Schema, CreateRequestBody(request)));
        }
    }
}
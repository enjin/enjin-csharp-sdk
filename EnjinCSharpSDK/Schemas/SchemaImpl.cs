using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.PlayerSchema;
using Enjin.SDK.ProjectSchema;
using Enjin.SDK.Shared;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    public class SchemaImpl : BaseService, IProjectSchema, IPlayerSchema
    {
        private readonly IProjectService _projectService;
        private readonly IPlayerService _playerService;

        public SchemaImpl(TrustedPlatformMiddleware middleware) : base(middleware)
        {
            _projectService = CreateService<IProjectService>();
            _playerService = CreateService<IPlayerService>();
        }

        public GraphqlResponse<AccessToken> AuthProject(AuthProject query)
        {
            return SendRequest(_projectService.Auth(CreateRequestBody(query, ""))).Result;
        }
        
        public GraphqlResponse<Project> GetProject(GetProject query)
        {
            return SendRequest(_projectService.GetOne(CreateRequestBody(query, ""))).Result;
        }

        public GraphqlResponse<AccessToken> AuthPlayer(AuthPlayer query)
        {
            return SendRequest(_playerService.Auth(CreateRequestBody(query, ""))).Result;
        }

        public GraphqlResponse<Player> GetPlayer(ProjectSchema.GetPlayer query)
        {
            return SendRequest(_playerService.GetOne(CreateRequestBody(query, ""))).Result;
        }

        public GraphqlResponse<List<Player>> GetPlayers(GetPlayers query)
        {
            return SendRequest(_playerService.GetMany(CreateRequestBody(query, ""))).Result;
        }

        public GraphqlResponse<Player> GetPlayer(PlayerSchema.GetPlayer query)
        {
            return SendRequest(_playerService.GetOne(CreateRequestBody(query, ""))).Result;
        }
    }

    [Headers("Content-Type: application/json")]
    internal interface IProjectService : IAuth, IGetOne<Project>
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IPlayerService : IAuth, IGetOne<Player>, IGetMany<Player>
    {
    }

    [Headers("Content-Type: application/json")]
    internal interface IAuth
    {
        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> Auth([Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetOne<T>
    {
        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<T>>> GetOne([Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetMany<T>
    {
        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<List<T>>>> GetMany([Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}
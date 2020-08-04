using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
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

        public GraphqlResponse<AccessToken> AuthProject(AuthProject request)
        {
            return SendRequest(_projectService.Auth(Middleware.Schema, CreateRequestBody(request))).Result;
        }
        
        public GraphqlResponse<Project> GetProject(GetProject request)
        {
            return SendRequest(_projectService.GetOne(Middleware.Schema, CreateRequestBody(request))).Result;
        }

        public GraphqlResponse<AccessToken> CreatePlayer(CreatePlayer request)
        {
            return SendRequest(_playerService.Auth(Middleware.Schema, CreateRequestBody(request))).Result;
        }

        public GraphqlResponse<AccessToken> AuthPlayer(AuthPlayer request)
        {
            return SendRequest(_playerService.Auth(Middleware.Schema, CreateRequestBody(request))).Result;
        }

        public GraphqlResponse<Player> GetPlayer(ProjectSchema.GetPlayer request)
        {
            return SendRequest(_playerService.GetOne(Middleware.Schema, CreateRequestBody(request))).Result;
        }

        public GraphqlResponse<List<Player>> GetPlayers(GetPlayers request)
        {
            return SendRequest(_playerService.GetMany(Middleware.Schema, CreateRequestBody(request))).Result;
        }

        public GraphqlResponse<bool> DeletePlayer(DeletePlayer request)
        {
            return SendRequest(_playerService.Delete(Middleware.Schema, CreateRequestBody(request))).Result;
        }

        public GraphqlResponse<Player> GetPlayer(PlayerSchema.GetPlayer request)
        {
            return SendRequest(_playerService.GetOne(Middleware.Schema, CreateRequestBody(request))).Result;
        }
    }

    [Headers("Content-Type: application/json")]
    internal interface IProjectService : IAuth, IGetOne<Project>
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IPlayerService : IAuth, IGetOne<Player>, IGetMany<Player>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<bool>>> Delete(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }

    [Headers("Content-Type: application/json")]
    internal interface IAuth
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> Auth(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetOne<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<T>>> GetOne(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetMany<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<List<T>>>> GetMany(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}
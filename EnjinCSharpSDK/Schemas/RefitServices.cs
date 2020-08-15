using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    [Headers("Content-Type: application/json")]
    internal interface IPlayerService : IAuth, IGetOne<Player>, IGetMany<Player>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<bool>>> Delete(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IProjectService : IAuth, IGetOne<Project>
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IAuth
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> Auth(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetMany<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<List<T>>>> GetMany(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetOne<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<T>>> GetOne(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}
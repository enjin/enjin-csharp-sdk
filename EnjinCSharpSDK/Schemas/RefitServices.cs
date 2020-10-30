using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using Refit;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK
{
    [Headers("Content-Type: application/json")]
    internal interface IPlayerService : IAuth, IGetOne<Player>, IGetMany<Player>, IDelete
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IProjectService : IAuth, IGetOne<Project>
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IBalanceService : IGetMany<Balance>
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IPlatformService : IGetOne<Platform>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<GasPrices>>> GetGasPrices(string schema,
            [Body(BodySerializationMethod.Serialized)] JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IRequestService : IGetOne<Request>, IGetMany<Request>, IDelete
    {
    }
    
    [Headers("Content-Type: application/json")]
    internal interface ITokenService : IGetOne<Token>, IGetMany<Token>, IDelete
    {
    }

    [Headers("Content-Type: application/json")]
    internal interface IWalletService : IGetOne<Wallet>, IGetMany<Wallet>
    {
    }

    [Headers("Content-Type: application/json")]
    internal interface IAuth
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> Auth(string schema,
            [Body(BodySerializationMethod.Serialized)] JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetMany<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<List<T>>>> GetMany(string schema,
            [Body(BodySerializationMethod.Serialized)] JObject body);
    }
    
    [Headers("Content-Type: application/json")]
    internal interface IGetOne<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<T>>> GetOne(string schema,
            [Body(BodySerializationMethod.Serialized)] JObject body);
    }

    [Headers("Content-Type: application/json")]
    internal interface IDelete
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<bool>>> Delete(string schema,
            [Body(BodySerializationMethod.Serialized)] JObject body);
    }
}
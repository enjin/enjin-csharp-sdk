using System.Collections.Generic;
using System.Threading.Tasks;
using EnjinSDK.Graphql;
using EnjinSDK.Models;
using EnjinSDK.Models.App;
using Newtonsoft.Json.Linq;
using Refit;

namespace EnjinSDK.Services.App
{
    public class AppService : BaseService, IAppService
    {
        private readonly IRefitAppService _service;

        public AppService(TrustedPlatformMiddleware middleware) : base(middleware)
        {
            _service = CreateService<IRefitAppService>();
        }

        public GraphqlResponse<AccessToken> AuthApp(AuthApp query)
        {
            return SendRequest(_service.RequestAuth(CreateRequestBody(query, "AuthAppQuery"))).Result;
        }

        public GraphqlResponse<Application> CreateApp(CreateApp query)
        {
            return SendRequest(_service.RequestOne(CreateRequestBody(query, "CreateAppMutation"))).Result;
        }

        public GraphqlResponse<Application> GetApp(GetApp query)
        {
            return SendRequest(_service.RequestOne(CreateRequestBody(query, "GetAppQuery"))).Result;
        }

        public GraphqlResponse<List<Application>> GetApps(GetApps query)
        {
            return SendRequest(_service.RequestMany(CreateRequestBody(query, query.IsSet("pagination")
                ? "GetAppsPaginatedQuery"
                : "GetAppsQuery"))).Result;
        }

        public GraphqlResponse<Application> UpdateApp(UpdateApp query)
        {
            return SendRequest(_service.RequestOne(CreateRequestBody(query, "UpdateAppMutation"))).Result;
        }

        public GraphqlResponse<Application> DeleteApp(DeleteApp query)
        {
            return SendRequest(_service.RequestOne(CreateRequestBody(query, "DeleteAppMutation"))).Result;
        }

        public GraphqlResponse<Application> UnlinkApp(UnlinkApp query)
        {
            return SendRequest(_service.RequestOne(CreateRequestBody(query, "UnlinkAppMutation"))).Result;
        }
    }

    [Headers("Content-Type: application/json")]
    internal interface IRefitAppService
    {
        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> RequestAuth([Body(BodySerializationMethod.Serialized)]
            JObject body);

        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<Application>>> RequestOne([Body(BodySerializationMethod.Serialized)]
            JObject body);

        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<List<Application>>>> RequestMany([Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}
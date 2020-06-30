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
            return SendRequest(_service.AuthApp(CreateRequestBody(query, "AuthAppQuery"))).Result;
        }
    }

    [Headers("Content-Type: application/json")]
    internal interface IRefitAppService
    {
        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> AuthApp([Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}
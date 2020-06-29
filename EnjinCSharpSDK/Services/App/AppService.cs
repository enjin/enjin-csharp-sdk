using System.Threading.Tasks;
using EnjinSDK.Graphql;
using EnjinSDK.Models;
using EnjinSDK.Models.App;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Refit;

namespace EnjinSDK.Services.App
{
    [PublicAPI]
    public class AppService : BaseService, IAppService
    {
        private readonly IRefitAppService _service;

        public AppService(TrustedPlatformMiddleware middleware) : base(middleware)
        {
            _service = CreateService<IRefitAppService>();
        }

        public Task<ApiResponse<GraphqlResponse<AccessToken>>> AuthApp(AuthApp query)
        {
            return _service.AuthApp(CreateRequestBody(query, "AuthAppQuery"));
        }
    }

    [Headers("Content-Type: application/json")]
    internal interface IRefitAppService
    {
        [Post("/graphql")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> AuthApp([Body(BodySerializationMethod.Serialized)] JObject body);
    }
}
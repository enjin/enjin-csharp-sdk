using System.Threading.Tasks;
using EnjinSDK.Graphql;
using EnjinSDK.Models;
using EnjinSDK.Models.App;
using Refit;

namespace EnjinSDK.Services.App
{
    public interface IAppService
    {
        Task<ApiResponse<GraphqlResponse<AccessToken>>> AuthApp(AuthApp query);
    }
}
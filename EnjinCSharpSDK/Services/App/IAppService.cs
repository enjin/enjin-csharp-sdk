using EnjinSDK.Graphql;
using EnjinSDK.Models;
using EnjinSDK.Models.App;
using JetBrains.Annotations;

namespace EnjinSDK.Services.App
{
    [PublicAPI]
    public interface IAppService
    {
        GraphqlResponse<AccessToken> AuthApp(AuthApp query);
    }
}
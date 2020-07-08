using System.Collections.Generic;
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

        GraphqlResponse<Application> CreateApp(CreateApp query);

        GraphqlResponse<Application> GetApp(GetApp query);

        GraphqlResponse<List<Application>> GetApps(GetApps query);

        GraphqlResponse<Application> UpdateApp(UpdateApp query);
        
        GraphqlResponse<Application> DeleteApp(DeleteApp query);

        GraphqlResponse<Application> UnlinkApp(UnlinkApp query);
    }
}
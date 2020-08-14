using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public interface IProjectSchema : ISharedSchema
    {
        Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject request);

        Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer request);

        Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer request);

        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer request);

        Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers request);

        Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer request);
    }
}
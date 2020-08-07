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
        Task<GraphqlResponse<AccessToken>> AuthProject(AuthProject query);

        Task<GraphqlResponse<AccessToken>> CreatePlayer(CreatePlayer query);

        Task<GraphqlResponse<AccessToken>> AuthPlayer(AuthPlayer query);

        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer query);

        Task<GraphqlResponse<List<Player>>> GetPlayers(GetPlayers query);

        Task<GraphqlResponse<bool>> DeletePlayer(DeletePlayer query);
    }
}
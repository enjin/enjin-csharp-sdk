using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public interface IProjectSchema : ISharedSchema
    {
        GraphqlResponse<AccessToken> AuthProject(AuthProject query);

        GraphqlResponse<AccessToken> AuthPlayer(AuthPlayer query);

        GraphqlResponse<Player> GetPlayer(GetPlayer query);

        GraphqlResponse<List<Player>> GetPlayers(GetPlayers query);
    }
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public interface IPlayerSchema : ISharedSchema
    {
        GraphqlResponse<Player> GetPlayer(GetPlayer query);
    }
}
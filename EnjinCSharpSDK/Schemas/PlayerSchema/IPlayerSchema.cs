using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public interface IPlayerSchema : ISharedSchema
    {
        Task<GraphqlResponse<Player>> GetPlayer(GetPlayer query);
    }
}
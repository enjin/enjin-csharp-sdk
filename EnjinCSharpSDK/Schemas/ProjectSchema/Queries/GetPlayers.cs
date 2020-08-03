using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class GetPlayers<T>
        : GraphqlRequest<T>, IPaginationArguments<T>, IPlayerFragmentArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T Filter(PlayerFilter filter)
        {
            return SetVariable("filter", filter);
        }
    }

    [PublicAPI]
    public class GetPlayers : GetPlayers<GetPlayers>
    {
    }
}
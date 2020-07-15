using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class GetPlayers<T> : PaginationRequest<T>, IPlayerFragmentArguments<T> where T : PaginationRequest<T>, new()
    {
        public T Id(PaginationOptions pagination)
        {
            return SetVariable("pagination", pagination);
        }
    }

    [PublicAPI]
    public class GetPlayers : GetPlayers<GetPlayers>
    {
    }
}
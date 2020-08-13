using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class GetPlayers
        : GraphqlRequest<GetPlayers>, IPaginationArguments<GetPlayers>, IPlayerFragmentArguments<GetPlayers>
    {
        public GetPlayers() : base("enjin.sdk.project.GetPlayers")
        {
        }

        public GetPlayers Filter(PlayerFilter filter)
        {
            return SetVariable("filter", filter);
        }
    }
}
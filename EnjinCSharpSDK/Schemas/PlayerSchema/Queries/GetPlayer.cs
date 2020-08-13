using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{

    [PublicAPI]
    public class GetPlayer : GraphqlRequest<GetPlayer>, IPlayerFragmentArguments<GetPlayer>
    {
        protected GetPlayer() : base("enjin.sdk.player.GetPlayer")
        {
        }
    }
}
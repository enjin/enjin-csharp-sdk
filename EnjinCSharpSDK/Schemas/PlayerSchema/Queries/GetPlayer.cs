using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public class GetPlayer<T> : GraphqlRequest<T>, IPlayerFragmentArguments<T> where T : GraphqlRequest<T>, new()
    {
    }
    
    [PublicAPI]
    public class GetPlayer : GetPlayer<GetPlayer>
    {}
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public class UnlinkWallet<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
    }
    
    [PublicAPI]
    public class UnlinkWallet : UnlinkWallet<UnlinkWallet>
    {}
}
using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public class UnlinkWallet<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        protected UnlinkWallet() : base("enjin.sdk.player.UnlinkWallet")
        {
        }
    }
    
    [PublicAPI]
    public class UnlinkWallet : UnlinkWallet<UnlinkWallet>
    {}
}
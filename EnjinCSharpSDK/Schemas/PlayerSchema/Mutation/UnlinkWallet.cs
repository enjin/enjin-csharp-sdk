using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    [PublicAPI]
    public class UnlinkWallet : GraphqlRequest<UnlinkWallet>
    {
        protected UnlinkWallet() : base("enjin.sdk.player.UnlinkWallet")
        {
        }
    }
}
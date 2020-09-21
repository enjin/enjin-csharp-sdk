using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for unlinking a wallet from the player.
    /// </summary>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class UnlinkWallet : GraphqlRequest<UnlinkWallet>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public UnlinkWallet() : base("enjin.sdk.player.UnlinkWallet")
        {
        }
    }
}
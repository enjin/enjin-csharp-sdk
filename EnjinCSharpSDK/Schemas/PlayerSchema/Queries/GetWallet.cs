using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for getting the player's wallet.
    /// </summary>
    /// <seealso cref="Wallet"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class GetWallet : GraphqlRequest<GetWallet>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetWallet() : base("enjin.sdk.player.GetWallet")
        {
        }
    }
}
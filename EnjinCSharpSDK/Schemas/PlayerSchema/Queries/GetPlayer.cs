using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for getting information about the player.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Player"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class GetPlayer : GraphqlRequest<GetPlayer>, IPlayerFragmentArguments<GetPlayer>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetPlayer() : base("enjin.sdk.player.GetPlayer")
        {
        }
    }
}
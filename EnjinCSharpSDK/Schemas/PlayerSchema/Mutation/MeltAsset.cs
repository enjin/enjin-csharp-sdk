using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for melting a asset.
    /// </summary>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class MeltAsset : GraphqlRequest<MeltAsset>, ITransactionFragmentArguments<MeltAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public MeltAsset() : base("enjin.sdk.player.MeltAsset")
        {
        }

        /// <summary>
        /// Sets the melts to be performed.
        /// </summary>
        /// <param name="melts">The melts.</param>
        /// <returns>This request for chaining.</returns>
        public MeltAsset Melts(params Melt[]? melts)
        {
            return SetVariable("melts", melts);
        }
    }
}
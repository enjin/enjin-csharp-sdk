using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for melting a item.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class MeltToken : GraphqlRequest<MeltToken>, ITransactionRequestArguments<MeltToken>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public MeltToken() : base("enjin.sdk.shared.MeltToken")
        {
        }

        /// <summary>
        /// Sets the melts to be performed.
        /// </summary>
        /// <param name="melts">The melts.</param>
        /// <returns>This request for chaining.</returns>
        public MeltToken Melts(params Melt[] melts)
        {
            return SetVariable("melts", melts);
        }
    }
}
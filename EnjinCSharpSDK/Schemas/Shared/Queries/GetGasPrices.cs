using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting the latest gas prices.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.GasPrices"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetGasPrices : GraphqlRequest<GetGasPrices>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetGasPrices() : base("enjin.sdk.shared.GetGasPrices")
        {
        }
    }
}
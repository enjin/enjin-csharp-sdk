using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetGasPrices : GraphqlRequest<GetGasPrices>
    {
        public GetGasPrices() : base("enjin.sdk.shared.GetGasPrices")
        {
        }
    }
}
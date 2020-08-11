using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetGasPrices<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        protected GetGasPrices() : base("enjin.sdk.shared.GetGasPrices")
        {
        }
    }
    
    [PublicAPI]
    public class GetGasPrices : GetGasPrices<GetGasPrices>
    {}
}
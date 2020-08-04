using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class MeltToken<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected MeltToken() : base("enjin.sdk.shared.MeltToken")
        {
        }

        public T Melts(params Melt[] melts)
        {
            return SetVariable("melts", melts);
        }
    }
    
    [PublicAPI]
    public class MeltToken : MeltToken<MeltToken>
    {}
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class MeltToken : GraphqlRequest<MeltToken>, ITransactionRequestArguments<MeltToken>
    {
        public MeltToken() : base("enjin.sdk.shared.MeltToken")
        {
        }

        public MeltToken Melts(params Melt[] melts)
        {
            return SetVariable("melts", melts);
        }
    }
}
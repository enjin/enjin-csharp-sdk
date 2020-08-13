using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class CompleteTrade : GraphqlRequest<CompleteTrade>, ITransactionRequestArguments<CompleteTrade>
    {
        public CompleteTrade() : base("enjin.sdk.shared.CompleteTrade")
        {
        }

        public CompleteTrade TradeId(string id)
        {
            return SetVariable("tradeId", id);
        }
    }
}
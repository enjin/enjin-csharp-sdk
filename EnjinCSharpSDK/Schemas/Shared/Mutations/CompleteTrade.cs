using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class CompleteTrade<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected CompleteTrade() : base("enjin.sdk.shared.CompleteTrade")
        {
        }

        public T TradeId(string id)
        {
            return SetVariable("tradeId", id);
        }
    }
    
    [PublicAPI]
    public class CompleteTrade : CompleteTrade<CompleteTrade>
    {}
}
using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for completing a trade between two wallets.
    /// </summary>
    /// <seealso cref="CreateTrade"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class CompleteTrade : GraphqlRequest<CompleteTrade>, ITransactionRequestArguments<CompleteTrade>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CompleteTrade() : base("enjin.sdk.shared.CompleteTrade")
        {
        }

        /// <summary>
        /// Sets the trade ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public CompleteTrade TradeId(string? id)
        {
            return SetVariable("tradeId", id);
        }
    }
}
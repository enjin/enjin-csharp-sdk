using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for completing a trade between two wallets.
    /// </summary>
    /// <seealso cref="CreateTrade"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class CompleteTrade : GraphqlRequest<CompleteTrade>, ITransactionFragmentArguments<CompleteTrade>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CompleteTrade() : base("enjin.sdk.player.CompleteTrade")
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
using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for completing a trade between two wallets.
    /// </summary>
    /// <seealso cref="CreateTrade"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class CompleteTrade : GraphqlRequest<CompleteTrade>, IProjectTransactionRequestArguments<CompleteTrade>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CompleteTrade() : base("enjin.sdk.project.CompleteTrade")
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
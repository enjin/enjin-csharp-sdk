using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for creating a trade between two wallets.
    /// </summary>
    /// <seealso cref="CompleteTrade"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class CreateTrade : GraphqlRequest<CreateTrade>, ITransactionRequestArguments<CreateTrade>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CreateTrade() : base("enjin.sdk.shared.CreateTrade")
        {
        }

        /// <summary>
        /// Sets the tokens (items) the sender is asking for.
        /// </summary>
        /// <param name="tokens">The items.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade AskingTokens(params Trade[] tokens)
        {
            return SetVariable("askingTokens", tokens);
        }

        /// <summary>
        /// Sets the tokens (items) to be offered by the sender.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade OfferingTokens(params Trade[] tokens)
        {
            return SetVariable("offeringTokens", tokens);
        }

        /// <summary>
        /// Sets the wallet address of the recipient.
        /// </summary>
        /// <param name="recipientAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }
    }
}
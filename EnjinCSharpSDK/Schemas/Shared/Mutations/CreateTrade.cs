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
        /// Sets the assets the sender is asking for.
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade AskingAssets(params Trade[] assets)
        {
            return SetVariable("askingAssets", assets);
        }

        /// <summary>
        /// Sets the assets to be offered by the sender.
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <returns>This request for chaining.</returns>
        public CreateTrade OfferingAssets(params Trade[] assets)
        {
            return SetVariable("offeringAssets", assets);
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
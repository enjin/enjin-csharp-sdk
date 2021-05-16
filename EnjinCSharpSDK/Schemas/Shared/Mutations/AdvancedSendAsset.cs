using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for sending one or more assets in a single transaction.
    /// </summary>
    /// <seealso cref="SendAsset"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class AdvancedSendAsset : GraphqlRequest<AdvancedSendAsset>, ITransactionRequestArguments<AdvancedSendAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public AdvancedSendAsset() : base("enjin.sdk.shared.AdvancedSendAsset")
        {
        }

        /// <summary>
        /// Sets the different transfers to perform.
        /// </summary>
        /// <param name="transfers">The transfers.</param>
        /// <returns>This request for chaining.</returns>
        public AdvancedSendAsset Transfers(params Transfer[]? transfers)
        {
            return SetVariable("transfers", transfers);
        }

        /// <summary>
        /// Sets the data to forward with the transaction.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>This request for chaining.</returns>
        public AdvancedSendAsset Data(string? data)
        {
            return SetVariable("data", data);
        }
    }
}
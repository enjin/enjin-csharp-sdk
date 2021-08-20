using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for sending one or more assets in a single transaction.
    /// </summary>
    /// <seealso cref="SendAsset"/>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class AdvancedSendAsset : GraphqlRequest<AdvancedSendAsset>, ITransactionFragmentArguments<AdvancedSendAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public AdvancedSendAsset() : base("enjin.sdk.player.AdvancedSendAsset")
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
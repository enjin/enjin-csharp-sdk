using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for sending one or more assets in a single transaction.
    /// </summary>
    /// <seealso cref="SendAsset"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class AdvancedSendAsset : GraphqlRequest<AdvancedSendAsset>, IProjectTransactionRequestArguments<AdvancedSendAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public AdvancedSendAsset() : base("enjin.sdk.project.AdvancedSendAsset")
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
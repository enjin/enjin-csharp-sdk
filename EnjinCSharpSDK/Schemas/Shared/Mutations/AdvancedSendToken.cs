using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for sending one or more items in a single transaction.
    /// </summary>
    /// <seealso cref="SendToken"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class AdvancedSendToken : GraphqlRequest<AdvancedSendToken>, ITransactionRequestArguments<AdvancedSendToken>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public AdvancedSendToken() : base("enjin.sdk.shared.AdvancedSendToken")
        {
        }

        /// <summary>
        /// Sets the different transfers to perform.
        /// </summary>
        /// <param name="transfers">The transfers.</param>
        /// <returns>This request for chaining.</returns>
        public AdvancedSendToken Transfers(params Transfer[] transfers)
        {
            return SetVariable("transfers", transfers);
        }

        /// <summary>
        /// Sets the data to forward with the transaction.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>This request for chaining.</returns>
        public AdvancedSendToken Data(string data)
        {
            return SetVariable("data", data);
        }
    }
}
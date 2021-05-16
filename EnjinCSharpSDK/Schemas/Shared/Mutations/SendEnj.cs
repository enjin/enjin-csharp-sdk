using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for sending ENJ.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class SendEnj : GraphqlRequest<SendEnj>, ITransactionRequestArguments<SendEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SendEnj() : base("enjin.sdk.shared.SendEnj")
        {
        }

        /// <summary>
        /// Sets the wallet address of the recipient.
        /// </summary>
        /// <param name="recipientAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SendEnj RecipientAddress(string? recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        /// <summary>
        /// Sets the amount of ENJ to send.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The value is in Wei as 10^18 (e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public SendEnj Value(string? value)
        {
            return SetVariable("value", value);
        }
    }
}
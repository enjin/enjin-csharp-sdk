using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for sending a token (item).
    /// </summary>
    /// <seealso cref="AdvancedSendToken"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class SendToken : GraphqlRequest<SendToken>, ITransactionRequestArguments<SendToken>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SendToken() : base("enjin.sdk.shared.SendToken")
        {
        }

        /// <summary>
        /// Sets the wallet address of the recipient.
        /// </summary>
        /// <param name="recipientAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SendToken RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SendToken TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }

        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SendToken TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }

        /// <summary>
        /// Sets the amount to send.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This request for chaining.</returns>
        public SendToken Value(string value)
        {
            return SetVariable("value", value);
        }

        /// <summary>
        /// Sets the data to forward with the transaction.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>This request for chaining.</returns>
        public SendToken Data(string data)
        {
            return SetVariable("data", data);
        }
    }
}
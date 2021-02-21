using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for sending a asset.
    /// </summary>
    /// <seealso cref="AdvancedSendAsset"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class SendAsset : GraphqlRequest<SendAsset>, ITransactionRequestArguments<SendAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SendAsset() : base("enjin.sdk.shared.SendAsset")
        {
        }

        /// <summary>
        /// Sets the wallet address of the recipient.
        /// </summary>
        /// <param name="recipientAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset AssetId(string assetId)
        {
            return SetVariable("assetId", assetId);
        }

        /// <summary>
        /// Sets the index for non-fungible assets.
        /// </summary>
        /// <param name="assetIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset AssetIndex(string assetIndex)
        {
            return SetVariable("assetIndex", assetIndex);
        }

        /// <summary>
        /// Sets the amount to send.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset Value(string value)
        {
            return SetVariable("value", value);
        }

        /// <summary>
        /// Sets the data to forward with the transaction.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>This request for chaining.</returns>
        public SendAsset Data(string data)
        {
            return SetVariable("data", data);
        }
    }
}
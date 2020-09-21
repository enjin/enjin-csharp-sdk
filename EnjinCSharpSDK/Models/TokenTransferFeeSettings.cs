using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models transfer fee settings for an item.
    /// </summary>
    /// <seealso cref="Token"/>
    [PublicAPI]
    public class TokenTransferFeeSettings
    {
        /// <summary>
        /// Represents the transfer fee type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TokenTransferFeeType? Type { get; internal set; }
        
        /// <summary>
        /// Represents the token (item) ID or "0" if ENJ.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("tokenId")]
        public string TokenId { get; internal set; }
        
        /// <summary>
        /// Represents the fee value in Wei.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string Value { get; internal set; }
    }

    /// <summary>
    /// Models input for the transfer fee settings used in token requests.
    /// </summary>
    [PublicAPI]
    public class TokenTransferFeeSettingsInput: TokenTransferFeeSettings
    {
        /// <summary>
        /// Sets the transfer type for this input.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>This input for chaining.</returns>
        public TokenTransferFeeSettingsInput Type(TokenTransferFeeType? type)
        {
            base.Type = type;
            return this;
        }

        /// <summary>
        /// Sets the token (item) ID for this input.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This input for chaining.</returns>
        /// <remarks>
        /// If the ID is set to "0", then this will be set to transfer ENJ instead of a token.
        /// </remarks>
        public TokenTransferFeeSettingsInput TokenId(string tokenId)
        {
            base.TokenId = tokenId;
            return this;
        }

        /// <summary>
        /// Sets the value in Wei for this input.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This input for chaining.</returns>
        public TokenTransferFeeSettingsInput Value(string value)
        {
            base.Value = value;
            return this;
        }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a trade input for requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.CreateTrade"/>
    [PublicAPI]
    public class Trade
    {
        [JsonProperty("tokenId")]
        private string _tokenid;
        [JsonProperty("tokenIndex")]
        private string _tokenIndex;
        [JsonProperty("value")]
        private string _value;

        /// <summary>
        /// Sets the token (item) ID to trade or ENJ if not used or set to <c>null</c>.
        /// </summary>
        /// <param name="tokenId">The token ID.</param>
        /// <returns>This input for chaining.</returns>
        public Trade TokenId(string tokenId)
        {
            _tokenid = tokenId;
            return this;
        }

        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This input for chaining.</returns>
        public Trade TokenIndex(string tokenIndex)
        {
            _tokenIndex = tokenIndex;
            return this;
        }

        /// <summary>
        /// Sets the number of items to trade.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This input for chaining.</returns>
        /// <remarks>
        /// If trading ENJ, the value is the amount to send in Wei (10^18 e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public Trade Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
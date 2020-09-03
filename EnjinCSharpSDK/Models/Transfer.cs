using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models transfer input when making requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.AdvancedSendToken"/>
    [PublicAPI]
    public class Transfer
    {
        [JsonProperty("from")]
        private string _from;
        [JsonProperty("to")]
        private string _to;
        [JsonProperty("tokenId")]
        private string _tokenId;
        [JsonProperty("tokenIndex")]
        private string _tokenIndex;
        [JsonProperty("value")]
        private string _value;

        /// <summary>
        /// Sets the source of the funds.
        /// </summary>
        /// <param name="address">The source.</param>
        /// <returns>This input chaining.</returns>
        public Transfer From(string address)
        {
            _from = address;
            return this;
        }
        
        /// <summary>
        /// Sets the destination of the funds.
        /// </summary>
        /// <param name="address">The destination.</param>
        /// <returns>This input chaining.</returns>
        public Transfer To(string address)
        {
            _to = address;
            return this;
        }
        
        /// <summary>
        /// Sets the token (item) ID to transfer or ENJ if not used or set to <c>null</c>.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This input chaining.</returns>
        public Transfer TokenId(string id)
        {
            _tokenId = id;
            return this;
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>This input chaining.</returns>
        public Transfer TokenIndex(string index)
        {
            _tokenIndex = index;
            return this;
        }
        
        /// <summary>
        /// Sets the number of items to transfer.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This input chaining.</returns>
        /// <remarks>
        /// If transferring ENJ, the value is the amount to send in Wei (10^18 e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public Transfer Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a melt input for melt requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.MeltToken"/>
    [PublicAPI]
    public class Melt
    {
        [JsonProperty("tokenId")]
        private string _tokenid;
        [JsonProperty("tokenIndex")]
        private string _tokenIndex;
        [JsonProperty("value")]
        private string _value;

        /// <summary>
        /// Sets the token (item) ID to melt.
        /// </summary>
        /// <param name="tokenId">The token ID.</param>
        /// <returns>This input for chaining.</returns>
        public Melt TokenId(string tokenId)
        {
            _tokenid = tokenId;
            return this;
        }

        /// <summary>
        /// Sets the token (item) index of a non-fungible item to melt.
        /// </summary>
        /// <param name="tokenIndex">The token index.</param>
        /// <returns>This input for chaining.</returns>
        public Melt TokenIndex(string tokenIndex)
        {
            _tokenIndex = tokenIndex;
            return this;
        }

        /// <summary>
        /// Sets the number of items to melt.
        /// </summary>
        /// <param name="value">The amount of items.</param>
        /// <returns>This input for chaining.</returns>
        public Melt Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
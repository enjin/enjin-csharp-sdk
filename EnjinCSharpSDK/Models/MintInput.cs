using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a mint input for mint requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.ProjectSchema.MintToken"/>
    [PublicAPI]
    public class MintInput
    {
        [JsonProperty("to")]
        private string _to;
        [JsonProperty("value")]
        private string _value;

        /// <summary>
        /// Sets the Ethereum address to mint to.
        /// </summary>
        /// <param name="ethAddress">The address.</param>
        /// <returns>This input for chaining.</returns>
        public MintInput To(string ethAddress)
        {
            _to = ethAddress;
            return this;
        }

        /// <summary>
        /// Sets the amount of items to mint.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This input for chaining.</returns>
        public MintInput Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
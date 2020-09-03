using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a token balance.
    /// </summary>
    [PublicAPI]
    public class Balance
    {
        /// <summary>
        /// Represents the token (item) ID for this balance.
        /// </summary>
        /// <value>The ID of the token.</value>
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        /// <summary>
        /// Represents the token (item) index for this balance.
        /// </summary>
        /// <value>The index of the token.</value>
        [JsonProperty("index")]
        public string Index { get; private set; }
        
        /// <summary>
        /// Represents the balance for the token.
        /// </summary>
        /// <value>The amount in the balance.</value>
        [JsonProperty("value")]
        public int Value { get; private set; }
        
        /// <summary>
        /// Represents the project for this balance's token.
        /// </summary>
        /// <value>The project model.</value>
        [JsonProperty("app")]
        public Project Project { get; private set; }
        
        /// <summary>
        /// Represents the wallet for this balance.
        /// </summary>
        /// <value>The wallet model.</value>
        [JsonProperty("wallet")]
        public Wallet Wallet { get; private set; }
    }
}
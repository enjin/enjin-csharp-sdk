using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a smart contract used by the platform.
    /// </summary>
    [PublicAPI]
    public class Contracts
    {
        /// <summary>
        /// Represents the ENJ contract address.
        /// </summary>
        /// <value>The contract address.</value>
        [JsonProperty("enj")]
        public string? Enj { get; private set; }
        
        /// <summary>
        /// Represents the crypto items contract address.
        /// </summary>
        /// <value>The contract address.</value>
        [JsonProperty("cryptoItems")]
        public string? CryptoItems { get; private set; }
        
        /// <summary>
        /// Represents the platform registry contract address.
        /// </summary>
        /// <value>The contract address.</value>
        [JsonProperty("platformRegistry")]
        public string? PlatformRegistry { get; private set; }
        
        /// <summary>
        /// Represents the supply models used by the platform.
        /// </summary>
        /// <value>The supply models.</value>
        [JsonProperty("supplyModels")]
        public SupplyModels? SupplyModels { get; private set; }
    }
}
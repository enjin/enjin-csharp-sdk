using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models data about the platform.
    /// </summary>
    [PublicAPI]
    public class Platform
    {
        /// <summary>
        /// Represents the ID of this platform.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public int? Id { get; private set; }
        
        /// <summary>
        /// Represents the name of this platform.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; private set; }
        
        /// <summary>
        /// Represents the current Ethereum network this platform is using.
        /// </summary>
        /// <value>The network.</value>
        [JsonProperty("network")]
        public string? Network { get; private set; }
        
        /// <summary>
        /// Represents the smart contracts used by this platform.
        /// </summary>
        /// <value>The contracts.</value>
        [JsonProperty("contracts")]
        public Contracts? Contracts { get; private set; }
        
        /// <summary>
        /// Represents the notification drivers that this platform is using.
        /// </summary>
        /// <value>The notifications.</value>
        [JsonProperty("notifications")]
        public Notifications? Notifications { get; private set; }
    }
}
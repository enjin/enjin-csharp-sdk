using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models Pusher channels used by the platform.
    /// </summary>
    [PublicAPI]
    public class PusherChannels
    {
        /// <summary>
        /// Represents the app channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("app")]
        public string Project { get; private set; }
        
        /// <summary>
        /// Represents the player channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("player")]
        public string Player { get; private set; }
        
        /// <summary>
        /// Represents the asset channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("asset")]
        public string Asset { get; private set; }
        
        /// <summary>
        /// Represents the wallet channel.
        /// </summary>
        /// <value>The channel string.</value>
        [JsonProperty("wallet")]
        public string Wallet { get; private set; }
    }
}
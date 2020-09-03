using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models Pusher settings for the platform.
    /// </summary>
    [PublicAPI]
    public class Pusher
    {
        /// <summary>
        /// Represents the key for the platform.
        /// </summary>
        /// <value>The key.</value>
        [JsonProperty("key")]
        public string Key { get; private set; }
        
        /// <summary>
        /// Represents the namespace the platform broadcasts on.
        /// </summary>
        /// <value>The namespace.</value>
        [JsonProperty("namespace")]
        public string Namespace { get; private set; }
        
        /// <summary>
        /// Represents the Pusher channels the platform broadcasts on.
        /// </summary>
        /// <value>The Pusher channels.</value>
        [JsonProperty("channels")]
        public PusherChannels Channels { get; private set; }
        
        /// <summary>
        /// Represents the options for Pusher that the platform uses.
        /// </summary>
        /// <value>The Pusher options.</value>
        [JsonProperty("options")]
        public PusherOptions Options { get; private set; }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models Pusher options used by the platform.
    /// </summary>
    [PublicAPI]
    public class PusherOptions
    {
        /// <summary>
        /// Represents the cluster the platform is in.
        /// </summary>
        /// <value>The cluster.</value>
        [JsonProperty("cluster")]
        public string? Cluster { get; private set; }
        
        /// <summary>
        /// Represents the encryption setting the platform uses.
        /// </summary>
        /// <value>Whether encryption is used or not.</value>
        [JsonProperty("encrypted")]
        public bool? Encrypted { get; private set; }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the notifications settings for the platform.
    /// </summary>
    [PublicAPI]
    public class Notifications
    {
        /// <summary>
        /// Represents the Pusher settings of the platform.
        /// </summary>
        /// <value>The Pusher settings.</value>
        [JsonProperty("pusher")]
        public Pusher? Pusher { get; private set; }
    }
}
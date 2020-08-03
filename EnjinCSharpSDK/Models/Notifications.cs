using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Notifications
    {
        [JsonProperty("pusher")]
        public Pusher Pusher { get; private set; }
    }
}
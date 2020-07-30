using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Pusher
    {
        [JsonProperty("key")]
        public string Key { get; private set; }
        
        [JsonProperty("namespace")]
        public string Namespace { get; private set; }
        
        [JsonProperty("channels")]
        public PusherChannels Channels { get; private set; }
        
        [JsonProperty("options")]
        public PusherOptions Options { get; private set; }
    }
}
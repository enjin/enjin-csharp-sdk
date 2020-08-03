using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class PusherOptions
    {
        [JsonProperty("cluster")]
        public string Cluster { get; private set; }
        
        [JsonProperty("encrypted")]
        public bool Encrypted { get; private set; }
    }
}
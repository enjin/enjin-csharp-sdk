using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class PusherChannels
    {
        [JsonProperty("app")]
        public string Project { get; private set; }
        
        [JsonProperty("player")]
        public string Player { get; private set; }
        
        [JsonProperty("token")]
        public string Token { get; private set; }
        
        [JsonProperty("wallet")]
        public string Wallet { get; private set; }
    }
}
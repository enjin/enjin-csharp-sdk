using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Balance
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("index")]
        public string Index { get; private set; }
        
        [JsonProperty("value")]
        public int Value { get; private set; }
        
        [JsonProperty("app")]
        public Project Project { get; private set; }
        
        [JsonProperty("wallet")]
        public Wallet Wallet { get; private set; }
    }
}
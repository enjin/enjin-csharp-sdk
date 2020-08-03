using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Platform
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("network")]
        public string Network { get; private set; }
        
        [JsonProperty("contracts")]
        public Contracts Contracts { get; private set; }
        
        [JsonProperty("notifications")]
        public Notifications Notifications { get; private set; }
    }
}
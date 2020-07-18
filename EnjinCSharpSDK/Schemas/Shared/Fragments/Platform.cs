using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Shared
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

    [PublicAPI]
    public class Contracts
    {
        [JsonProperty("enj")]
        public string Enj { get; private set; }
        
        [JsonProperty("cryptoItems")]
        public string CryptoItems { get; private set; }
        
        [JsonProperty("platformRegistry")]
        public string PlatformRegistry { get; private set; }
        
        [JsonProperty("supplyModels")]
        public SupplyModels SupplyModels { get; private set; }
    }

    [PublicAPI]
    public class SupplyModels
    {
        [JsonProperty("fixed")]
        public string Fixed { get; private set; }
        
        [JsonProperty("settable")]
        public string Settable { get; private set; }
        
        [JsonProperty("infinite")]
        public string Infinite { get; private set; }
        
        [JsonProperty("collapsing")]
        public string Collapsing { get; private set; }
        
        [JsonProperty("annualValue")]
        public string AnnualValue { get; private set; }
        
        [JsonProperty("annualPercentage")]
        public string AnnualPercentage { get; private set; }
    }
    
    [PublicAPI]
    public class Notifications
    {
        [JsonProperty("pusher")]
        public Pusher Pusher { get; private set; }
    }

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

    [PublicAPI]
    public class PusherOptions
    {
        [JsonProperty("cluster")]
        public string Cluster { get; private set; }
        
        [JsonProperty("encrypted")]
        public bool Encrypted { get; private set; }
    }
}
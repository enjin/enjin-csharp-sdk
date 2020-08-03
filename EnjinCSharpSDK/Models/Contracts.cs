using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
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
}
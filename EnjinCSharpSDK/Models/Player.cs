using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Player
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("linkingCode")]
        public string LinkingCode { get; private set; }
        
        [JsonProperty("linkingCodeQr")]
        public string LinkingCodeQr { get; private set; }
        
        [JsonProperty("wallet")]
        public JObject Wallet { get; private set; }
        
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}
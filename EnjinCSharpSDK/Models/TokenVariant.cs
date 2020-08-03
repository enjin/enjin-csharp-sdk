using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TokenVariant
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        [JsonProperty("tokenId")]
        public string TokenId { get; private set; }
        
        [JsonProperty("variantMetadata")]
        public JObject VariantMetadata { get; private set; }
        
        [JsonProperty("usageCount")]
        public int UsageCount { get; private set; }
        
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}
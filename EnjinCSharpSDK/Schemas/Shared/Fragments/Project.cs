using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("secret")]
        public string Secret { get; private set; }
        
        [JsonProperty("description")]
        public string Description { get; private set; }
        
        [JsonProperty("image")]
        public string Image { get; private set; }
        
        [JsonProperty("linkingCode")]
        public string LinkingCode { get; private set; }
        
        [JsonProperty("linkingCodeQr")]
        public string LinkingCodeQr { get; private set; }
        
        // TODO: add identity and owner
        
        [JsonProperty("tokenCount")]
        public int TokenCount { get; private set; }
        
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class PaginationOptions
    {
        [JsonProperty("page")]
        public int? Page { get; set; }
        
        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}
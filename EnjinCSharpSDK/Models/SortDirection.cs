using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum SortDirection
    {
        [JsonProperty("asc")]
        ASCENDING,
        [JsonProperty("desc")]
        DESCENDING
    }
}
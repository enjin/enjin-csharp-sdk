using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Enum for sort direction in sorting inputs.
    /// </summary>
    [PublicAPI]
    public enum SortDirection
    {
        [JsonProperty("asc")]
        ASCENDING,
        [JsonProperty("desc")]
        DESCENDING
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum TransactionField
    {
        [JsonProperty("id")]
        ID,
        [JsonProperty("state")]
        STATE,
        [JsonProperty("title")]
        TITLE,
        [JsonProperty("createdAt")]
        CREATED_AT
    }
}
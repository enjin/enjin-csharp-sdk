using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The fields of the <see cref="Request"/> type.
    /// </summary>
    /// <seealso cref="TransactionSort"/>
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
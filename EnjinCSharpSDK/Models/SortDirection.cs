using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Enum for sort direction in sorting inputs.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum SortDirection
    {
        [EnumMember(Value = "asc")]
        ASCENDING,

        [EnumMember(Value = "desc")]
        DESCENDING,
    }
}
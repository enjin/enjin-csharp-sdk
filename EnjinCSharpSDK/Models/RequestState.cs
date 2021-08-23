using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the state of a request.
    /// </summary>
    /// <seealso cref="Request"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum RequestState
    {
        [EnumMember(Value = "PENDING")]
        PENDING,

        [EnumMember(Value = "BROADCAST")]
        BROADCAST,

        [EnumMember(Value = "TP_PROCESSING")]
        TP_PROCESSING,

        [EnumMember(Value = "EXECUTED")]
        EXECUTED,

        [EnumMember(Value = "CANCELED_USER")]
        CANCELED_USER,

        [EnumMember(Value = "CANCELED_PLATFORM")]
        CANCELED_PLATFORM,

        [EnumMember(Value = "DROPPED")]
        DROPPED,

        [EnumMember(Value = "FAILED")]
        FAILED,
    }
}
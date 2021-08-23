using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The fields of the <see cref="Request"/> type.
    /// </summary>
    /// <seealso cref="TransactionSort"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum TransactionField
    {
        [EnumMember(Value = "id")]
        ID,

        [EnumMember(Value = "state")]
        STATE,

        [EnumMember(Value = "title")]
        TITLE,

        [EnumMember(Value = "createdAt")]
        CREATED_AT,

        [EnumMember(Value = "updatedAt")]
        UPDATED_AT,
    }
}
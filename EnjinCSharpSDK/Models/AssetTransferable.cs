using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The transferable type.
    /// </summary>
    /// <seealso cref="Asset"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AssetTransferable
    {
        [EnumMember(Value = "PERMANENT")]
        PERMANENT,

        [EnumMember(Value = "TEMPORARY")]
        TEMPORARY,

        [EnumMember(Value = "BOUND")]
        BOUND,
    }
}
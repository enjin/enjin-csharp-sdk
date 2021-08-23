using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the mode that determines variant behaviour.
    /// </summary>
    /// <seealso cref="Asset"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AssetVariantMode
    {
        [EnumMember(Value = "NONE")]
        NONE,

        [EnumMember(Value = "BEAM")]
        BEAM,

        [EnumMember(Value = "ONCE")]
        ONCE,

        [EnumMember(Value = "ALWAYS")]
        ALWAYS,
    }
}
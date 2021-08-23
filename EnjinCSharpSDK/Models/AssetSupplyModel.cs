using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the asset supply model.
    /// </summary>
    /// <seealso cref="Asset"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AssetSupplyModel
    {
        [EnumMember(Value = "FIXED")]
        FIXED,

        [EnumMember(Value = "SETTABLE")]
        SETTABLE,

        [EnumMember(Value = "INFINITE")]
        INFINITE,

        [EnumMember(Value = "COLLAPSING")]
        COLLAPSING,

        [EnumMember(Value = "ANNUAL_VALUE")]
        ANNUAL_VALUE,

        [EnumMember(Value = "ANNUAL_PERCENTAGE")]
        ANNUAL_PERCENTAGE,
    }
}
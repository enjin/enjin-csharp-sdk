using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the format to render an asset's index.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AssetIndexFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,

        [EnumMember(Value = "uint64")]
        UINT64,
    }
}
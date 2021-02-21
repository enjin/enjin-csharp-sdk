using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the format to render an asset's index.
    /// </summary>
    [PublicAPI]
    public enum AssetIndexFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,
        [EnumMember(Value = "uint64")]
        UINT64
    }
}
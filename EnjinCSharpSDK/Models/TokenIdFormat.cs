using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the format to render an item's ID in.
    /// </summary>
    [PublicAPI]
    public enum TokenIdFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,
        [EnumMember(Value = "hex256")]
        HEX256,
        [EnumMember(Value = "uint256")]
        UINT256
    }
}
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
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
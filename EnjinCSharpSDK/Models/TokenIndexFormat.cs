using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum TokenIndexFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,
        [EnumMember(Value = "uint64")]
        UINT64
    }
}
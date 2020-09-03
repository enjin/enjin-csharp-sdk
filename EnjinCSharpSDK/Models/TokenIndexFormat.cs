using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the format to render an item's index.
    /// </summary>
    [PublicAPI]
    public enum TokenIndexFormat
    {
        [EnumMember(Value = "hex64")]
        HEX64,
        [EnumMember(Value = "uint64")]
        UINT64
    }
}
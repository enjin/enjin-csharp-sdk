using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the transfer fee type.
    /// </summary>
    /// <seealso cref="AssetTransferFeeSettings"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AssetTransferFeeType
    {
        [EnumMember(Value = "NONE")]
        NONE,

        [EnumMember(Value = "PER_TRANSFER")]
        PER_TRANSFER,

        [EnumMember(Value = "PER_CRYPTO_ITEM")]
        PER_CRYPTO_ITEM,

        [EnumMember(Value = "RATIO_CUT")]
        RATIO_CUT,

        [EnumMember(Value = "RATIO_EXTRA")]
        RATIO_EXTRA,
    }
}
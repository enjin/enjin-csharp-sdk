using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The fields of the <see cref="Asset"/> type.
    /// </summary>
    /// <seealso cref="AssetSort"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AssetField
    {
        [EnumMember(Value = "id")]
        ID,

        [EnumMember(Value = "name")]
        NAME,

        [EnumMember(Value = "circulatingSupply")]
        CIRCULATING_SUPPLY,

        [EnumMember(Value = "nonFungible")]
        NON_FUNGIBLE,

        [EnumMember(Value = "reserve")]
        RESERVE,

        [EnumMember(Value = "totalSupply")]
        TOTAL_SUPPLY,

        [EnumMember(Value = "createdAt")]
        CREATED_AT,
    }
}
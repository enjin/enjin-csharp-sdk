using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    public enum TokenField
    {
        [JsonProperty("id")]
        ID,
        [JsonProperty("name")]
        NAME,
        [JsonProperty("circulatingSupply")]
        CIRCULATING_SUPPLY,
        [JsonProperty("nonFungible")]
        NON_FUNGIBLE,
        [JsonProperty("reserve")]
        RESERVE,
        [JsonProperty("totalSupply")]
        TOTAL_SUPPLY,
        [JsonProperty("createdAt")]
        CREATED_AT
    }
}
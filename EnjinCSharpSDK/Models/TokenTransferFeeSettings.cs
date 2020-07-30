using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TokenTransferFeeSettings
    {
        [JsonProperty("type")]
        public TokenTransferFeeType Type { get; set; }
        
        [JsonProperty("tokenId")]
        public string TokenId { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
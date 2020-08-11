using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TokenTransferFeeSettings
    {
        [JsonProperty("type")]
        public TokenTransferFeeType Type { get; internal set; }
        
        [JsonProperty("tokenId")]
        public string TokenId { get; internal set; }
        
        [JsonProperty("value")]
        public string Value { get; internal set; }
    }

    [PublicAPI]
    public class TokenTransferFeeSettingsInput: TokenTransferFeeSettings
    {
        public TokenTransferFeeSettingsInput Type(TokenTransferFeeType type)
        {
            base.Type = type;
            return this;
        }

        public TokenTransferFeeSettingsInput TokenId(string tokenId)
        {
            base.TokenId = tokenId;
            return this;
        }

        public TokenTransferFeeSettingsInput Value(string value)
        {
            base.Value = value;
            return this;
        }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Trade
    {
        [JsonProperty("tokenId")]
        private string _tokenid;
        [JsonProperty("tokenIndex")]
        private string _tokenIndex;
        [JsonProperty("value")]
        private string _value;

        public Trade TokenId(string tokenId)
        {
            _tokenid = tokenId;
            return this;
        }

        public Trade TokenIndex(string tokenIndex)
        {
            _tokenIndex = tokenIndex;
            return this;
        }

        public Trade Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
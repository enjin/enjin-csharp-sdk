using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Melt
    {
        [JsonProperty("tokenId")]
        private string _tokenid;
        [JsonProperty("tokenIndex")]
        private string _tokenIndex;
        [JsonProperty("value")]
        private string _value;

        public Melt TokenId(string tokenId)
        {
            _tokenid = tokenId;
            return this;
        }

        public Melt TokenIndex(string tokenIndex)
        {
            _tokenIndex = tokenIndex;
            return this;
        }

        public Melt Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
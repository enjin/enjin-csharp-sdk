using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Transfer
    {
        [JsonProperty("from")]
        private string _from;
        [JsonProperty("to")]
        private string _to;
        [JsonProperty("tokenId")]
        private string _tokenId;
        [JsonProperty("tokenIndex")]
        private string _tokenIndex;
        [JsonProperty("value")]
        private string _value;

        public Transfer From(string address)
        {
            _from = address;
            return this;
        }
        
        public Transfer To(string address)
        {
            _to = address;
            return this;
        }
        
        public Transfer TokenId(string id)
        {
            _tokenId = id;
            return this;
        }
        
        public Transfer TokenIndex(string index)
        {
            _tokenIndex = index;
            return this;
        }
        
        public Transfer Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
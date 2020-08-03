using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class MintInput
    {
        [JsonProperty("to")]
        private string _to;
        [JsonProperty("value")]
        private string _value;

        public MintInput To(string ethAddress)
        {
            _to = ethAddress;
            return this;
        }

        public MintInput Value(string value)
        {
            _value = value;
            return this;
        }
    }
}
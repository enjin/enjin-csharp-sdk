using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class GasPrices
    {
        [JsonProperty("safeLow")]
        public float SafeLow { get; private set; }
        
        [JsonProperty("average")]
        public float Average { get; private set; }
        
        [JsonProperty("fast")]
        public float Fast { get; private set; }
        
        [JsonProperty("fastest")]
        public float Fastest { get; private set; }
    }
}
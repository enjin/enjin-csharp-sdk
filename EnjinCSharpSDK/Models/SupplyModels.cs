using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class SupplyModels
    {
        [JsonProperty("fixed")]
        public string Fixed { get; private set; }
        
        [JsonProperty("settable")]
        public string Settable { get; private set; }
        
        [JsonProperty("infinite")]
        public string Infinite { get; private set; }
        
        [JsonProperty("collapsing")]
        public string Collapsing { get; private set; }
        
        [JsonProperty("annualValue")]
        public string AnnualValue { get; private set; }
        
        [JsonProperty("annualPercentage")]
        public string AnnualPercentage { get; private set; }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the supply models used by the platform.
    /// </summary>
    [PublicAPI]
    public class SupplyModels
    {
        /// <summary>
        /// Represents the fixed model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("fixed")]
        public string Fixed { get; private set; }
        
        /// <summary>
        /// Represents the settable model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("settable")]
        public string Settable { get; private set; }
        
        /// <summary>
        /// Represents the infinite model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("infinite")]
        public string Infinite { get; private set; }
        
        /// <summary>
        /// Represents the collapsing model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("collapsing")]
        public string Collapsing { get; private set; }
        
        /// <summary>
        /// Represents the annual value model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("annualValue")]
        public string AnnualValue { get; private set; }
        
        /// <summary>
        /// Represents the annual percentage model.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("annualPercentage")]
        public string AnnualPercentage { get; private set; }
    }
}
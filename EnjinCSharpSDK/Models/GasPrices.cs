using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a gas prices object.
    /// </summary>
    [PublicAPI]
    public class GasPrices
    {
        /// <summary>
        /// The recommended safe gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 30 minutes.
        /// </remarks>
        [JsonProperty("safeLow")]
        public float? SafeLow { get; private set; }
        
        /// <summary>
        /// The recommended average gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 5 minutes.
        /// </remarks>
        [JsonProperty("average")]
        public float? Average { get; private set; }
        
        /// <summary>
        /// The recommended fast gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 2 minutes.
        /// </remarks>
        [JsonProperty("fast")]
        public float? Fast { get; private set; }
        
        /// <summary>
        /// The recommended fastest gas price in Gwei.
        /// </summary>
        /// <value>The gas price.</value>
        /// <remarks>
        /// Expected to be mined in less than 30 seconds.
        /// </remarks>
        [JsonProperty("fastest")]
        public float? Fastest { get; private set; }
    }
}
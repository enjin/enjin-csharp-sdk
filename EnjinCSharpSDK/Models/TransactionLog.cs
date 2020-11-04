using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a blockchain transaction log.
    /// </summary>
    [PublicAPI]
    public class TransactionLog
    {
        /// <summary>
        /// Represents the block number.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("blockNumber")]
        public int? BlockNumber { get; private set; }
        
        /// <summary>
        /// Represents the originating address.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("address")]
        public string? Address { get; private set; }
        
        /// <summary>
        /// Represents the hash of the transaction.
        /// </summary>
        /// <value>The transaction hash.</value>
        [JsonProperty("transactionHash")]
        public string? TransactionHash { get; private set; }
        
        /// <summary>
        /// Represents the list of data objects.
        /// </summary>
        /// <value>The list of data.</value>
        [JsonProperty("data")]
        public List<JObject>? Data { get; private set; }
        
        /// <summary>
        /// Represents the list of topics.
        /// </summary>
        /// <value>The list of topics.</value>
        [JsonProperty("topics")]
        public List<JObject>? Topics { get; private set; }
        
        /// <summary>
        /// Represents the transaction event.
        /// </summary>
        /// <value>The transaction event.</value>
        [JsonProperty("event")]
        public TransactionEvent? Event { get; private set; }
    }
}
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a transaction on the platform.
    /// </summary>
    [PublicAPI]
    public class Request
    {
        /// <summary>
        /// Represents the ID of this transaction.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// Represents the hash ID of this transaction.
        /// </summary>
        /// <value>The hash ID.</value>
        [JsonProperty("transactionId")]
        public string TransactionId { get; private set; } = null!;

        /// <summary>
        /// Represents the title of this transaction.
        /// </summary>
        /// <value>The transaction title.</value>
        [JsonProperty("title")]
        public string? Title { get; private set; }
        
        /// <summary>
        /// Represents the contract address for this transaction.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("contract")]
        public string? Contract { get; private set; }

        /// <summary>
        /// Represents the type of this transaction.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public RequestType Type { get; private set; }
        
        /// <summary>
        /// Represents the URL to the icon for this transaction.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("icon")]
        public string? Icon { get; private set; }
        
        /// <summary>
        /// Represents the value of this transaction.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string? Value { get; private set; }

        /// <summary>
        /// Represents the retry state for this transaction.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("retryState")]
        public string? RetryState { get; private set; }
        
        /// <summary>
        /// Represents the state of this transaction.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public RequestState? State { get; private set; }
        
        /// <summary>
        /// Represents if the transaction has been accepted or not.
        /// </summary>
        /// <value>Whether the transaction was accepted.</value>
        [JsonProperty("accepted")]
        public bool? Accepted { get; private set; }

        /// <summary>
        /// Represents the blockchain data of this transaction.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("blockchainData")]
        public BlockchainData? BlockchainData { get; private set; }
        
        /// <summary>
        /// Represents the token ID for this transaction.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("tokenId")]
        public string? TokenId { get; private set; }

        /// <summary>
        /// Represents the datetime when this transaction was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; } = null!;
        
        /// <summary>
        /// Represents the datetime when this transaction was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; } = null!;
    }
}
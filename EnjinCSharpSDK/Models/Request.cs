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
        public string TransactionId { get; private set; }
        
        /// <summary>
        /// Represents the title of this transaction.
        /// </summary>
        /// <value>The transaction title.</value>
        [JsonProperty("title")]
        public string Title { get; private set; }
        
        /// <summary>
        /// Represents the contract address for this transaction.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("contract")]
        public string Contract { get; private set; }
        
        /// <summary>
        /// Represents the encoded data of this transaction, ready for signing.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("encodedData")]
        public string EncodedData { get; private set; }
        
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
        public string Icon { get; private set; }
        
        /// <summary>
        /// Represents the value of this transaction.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string Value { get; private set; }
        
        /// <summary>
        /// Represents the signed string for this transaction.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedTransaction")]
        public string SignedTransaction { get; private set; }
        
        /// <summary>
        /// Represents the signed backup string for this transaction.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedBackupTransaction")]
        public string SignedBackupTransaction { get; private set; }
        
        /// <summary>
        /// Represents the signed cancel string for this transaction.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedCancelTransaction")]
        public string SignedCancelTransaction { get; private set; }
        
        /// <summary>
        /// Represents the error message for this transaction if one exists.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("error")]
        public string Error { get; private set; }
        
        /// <summary>
        /// Represents the nonce for this transaction.
        /// </summary>
        /// <value>The nonce.</value>
        [JsonProperty("nonce")]
        public string Nonce { get; private set; }
        
        /// <summary>
        /// Represents the retry state for this transaction.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("retryState")]
        public string RetryState { get; private set; }
        
        /// <summary>
        /// Represents the state of this transaction.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public RequestState State { get; private set; }
        
        /// <summary>
        /// Represents if the transaction has been accepted or not.
        /// </summary>
        /// <value>Whether the transaction was accepted.</value>
        [JsonProperty("accepted")]
        public bool Accepted { get; private set; }
        
        /// <summary>
        /// Represents the receipt for this transaction.
        /// </summary>
        /// <value>The receipt.</value>
        [JsonProperty("receipt")]
        public JObject Receipt { get; private set; }
        
        /// <summary>
        /// Represents the token ID for this transaction.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("tokenId")]
        public string TokenId { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this transaction was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this transaction was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}
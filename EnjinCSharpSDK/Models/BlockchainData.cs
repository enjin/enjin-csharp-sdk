using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the blockchain data of a <see cref="Request"/>.
    /// </summary>
    [PublicAPI]
    public class BlockchainData
    {
        /// <summary>
        /// Represents the encoded data of the transaction, ready for signing.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("encodedData")]
        public string? EncodedData { get; private set; }
        
        /// <summary>
        /// Represents the signed string for the transaction this data applies to.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedTransaction")]
        public string? SignedTransaction { get; private set; }
        
        /// <summary>
        /// Represents the signed backup string for the transaction this data applies to.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedBackupTransaction")]
        public string? SignedBackupTransaction { get; private set; }
        
        /// <summary>
        /// Represents the signed cancel string for the transaction this data applies to.
        /// </summary>
        /// <value>The signed string.</value>
        [JsonProperty("signedCancelTransaction")]
        public string? SignedCancelTransaction { get; private set; }
        
        /// <summary>
        /// Represents the receipt for the transaction this data applies to.
        /// </summary>
        /// <value>The receipt.</value>
        [JsonProperty("receipt")]
        public TransactionReceipt? Receipt { get; private set; }
        
        /// <summary>
        /// Represents the error message for the transaction this data applies to, if one exists.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("error")]
        public string? Error { get; private set; }
        
        /// <summary>
        /// Represents the nonce for the transaction this data applies to.
        /// </summary>
        /// <value>The nonce.</value>
        [JsonProperty("nonce")]
        public string? Nonce { get; private set; }
    }
}
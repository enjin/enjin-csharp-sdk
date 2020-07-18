using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class Request
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        [JsonProperty("transactionId")]
        public string TransactionId { get; private set; }
        
        [JsonProperty("title")]
        public string Title { get; private set; }
        
        [JsonProperty("contract")]
        public string Contract { get; private set; }
        
        [JsonProperty("encodedData")]
        public string EncodedData { get; private set; }
        
        [JsonProperty("type")]
        public RequestType Type { get; private set; }
        
        [JsonProperty("icon")]
        public string Icon { get; private set; }
        
        [JsonProperty("value")]
        public string Value { get; private set; }
        
        [JsonProperty("signedTransaction")]
        public string SignedTransaction { get; private set; }
        
        [JsonProperty("signedBackupTransaction")]
        public string SignedBackupTransaction { get; private set; }
        
        [JsonProperty("signedCancelTransaction")]
        public string SignedCancelTransaction { get; private set; }
        
        [JsonProperty("error")]
        public string Error { get; private set; }
        
        [JsonProperty("nonce")]
        public string Nonce { get; private set; }
        
        [JsonProperty("retryState")]
        public string RetryState { get; private set; }
        
        [JsonProperty("state")]
        public RequestState State { get; private set; }
        
        [JsonProperty("accepted")]
        public bool Accepted { get; private set; }
        
        [JsonProperty("receipt")]
        public JObject Receipt { get; private set; }
        
        [JsonProperty("tokenId")]
        public string TokenId { get; private set; }
        
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }

    [PublicAPI]
    public enum RequestType
    {
        APPROVE,
        CREATE,
        MINT,
        SEND,
        SEND_ENJ,
        ADVANCED_SEND,
        CREATE_TRADE,
        COMPLETE_TRADE,
        CANCEL_TRADE,
        MELT,
        UPDATE_NAME,
        SET_ITEM_URI,
        SET_WHITELISTED,
        SET_TRANSFERABLE,
        SET_MELT_FEE,
        DECREASE_MAX_MELT_FEE,
        SET_TRANSFER_FEE,
        DECREASE_MAX_TRANSFER_FEE,
        RELEASE_RESERVE,
        ADD_LOG,
        SET_APPROVAL_FOR_ALL,
        MANAGER_UPDATE,
        SET_DECIMALS,
        SET_SYMBOL,
        MESSAGE
    }

    [PublicAPI]
    public enum RequestState
    {
        PENDING,
        BROADCAST,
        TP_PROCESSING,
        EXECUTED,
        CANCELED_USER,
        CANCELED_PLATFORM,
        DROPPED,
        FAILED
    }
}
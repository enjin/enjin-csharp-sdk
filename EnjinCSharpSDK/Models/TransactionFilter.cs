using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TransactionFilter: Filter<TransactionFilter>
    {
        [JsonProperty("id")]
        private string _id;
        
        [JsonProperty("id_in")]
        private List<string> _idIn;

        [JsonProperty("transactionId")]
        private string _transactionId;

        [JsonProperty("transactionId_in")]
        private List<string> _transactionIdIn;

        [JsonProperty("tokenId")]
        private string _tokenId;

        [JsonProperty("tokenId_in")]
        private List<string> _tokenIdIn;

        [JsonProperty("type")]
        private RequestType _type;

        [JsonProperty("type_in")]
        private List<RequestType> _typeIn;

        [JsonProperty("value")]
        private int _value;

        [JsonProperty("value_gt")]
        private int _valueGt;

        [JsonProperty("value_gte")]
        private int _valueGte;

        [JsonProperty("value_lt")]
        private int _valueLt;

        [JsonProperty("value_lte")]
        private int _valueLte;

        [JsonProperty("state")]
        private RequestState _state;

        [JsonProperty("state_in")]
        private List<RequestState> _stateIn;
        
        [JsonProperty("wallet")]
        private string _wallet;

        [JsonProperty("wallet_in")]
        private List<string> _walletIn;
        
        public TransactionFilter Id(string id)
        {
            _id = id;
            return this;
        }

        public TransactionFilter IdIn(params string[] ids)
        {
            _idIn = ids.ToList();
            return this;
        }
        
        public TransactionFilter TransactionId(string transactionId)
        {
            _transactionId = transactionId;
            return this;
        }

        public TransactionFilter TransactionIdIn(params string[] transactionIds)
        {
            _transactionIdIn = transactionIds.ToList();
            return this;
        }
        
        public TransactionFilter TokenId(string tokenId)
        {
            _tokenId = tokenId;
            return this;
        }

        public TransactionFilter TokenIdIn(params string[] tokenIds)
        {
            _tokenIdIn = tokenIds.ToList();
            return this;
        }
        
        public TransactionFilter Type(RequestType type)
        {
            _type = type;
            return this;
        }

        public TransactionFilter Types(params RequestType[] types)
        {
            _typeIn = types.ToList();
            return this;
        }
        
        public TransactionFilter Value(int value)
        {
            _value = value;
            return this;
        }

        public TransactionFilter ValueGreaterThan(int value)
        {
            _valueGt = value;
            return this;
        }

        public TransactionFilter ValueGreaterThanOrEqual(int value)
        {
            _valueGte = value;
            return this;
        }

        public TransactionFilter ValueLessThan(int value)
        {
            _valueLt = value;
            return this;
        }

        public TransactionFilter ValueLessThanOrEqual(int value)
        {
            _valueLte = value;
            return this;
        }
        
        public TransactionFilter State(RequestState state)
        {
            _state = state;
            return this;
        }

        public TransactionFilter StateIn(params RequestState[] states)
        {
            _stateIn = states.ToList();
            return this;
        }
        
        public TransactionFilter Wallet(string wallet)
        {
            _wallet = wallet;
            return this;
        }

        public TransactionFilter WalletIn(params string[] wallets)
        {
            _walletIn = wallets.ToList();
            return this;
        }
    }
}
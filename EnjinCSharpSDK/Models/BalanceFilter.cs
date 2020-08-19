using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class BalanceFilter: Filter<BalanceFilter>
    {
        [JsonProperty("tokenId")]
        private string _tokenId;
        [JsonProperty("tokenId_in")]
        private List<string> _tokenIdIn;
        [JsonProperty("wallet")]
        private string _wallet;
        [JsonProperty("wallet_in")]
        private List<string> _walletIn;
        [JsonProperty("value")]
        private int? _value;
        [JsonProperty("value_gt")]
        private int? _valueGt;
        [JsonProperty("value_gte")]
        private int? _valueGte;
        [JsonProperty("value_lt")]
        private int? _valueLt;
        [JsonProperty("value_lte")]
        private int? _valueLte;
        
        public BalanceFilter TokenId(string tokenId)
        {
            _tokenId = tokenId;
            return this;
        }

        public BalanceFilter TokenIdIn(params string[] tokenIds)
        {
            _tokenIdIn = tokenIds.ToList();
            return this;
        }
        
        public BalanceFilter Value(int value)
        {
            _value = value;
            return this;
        }

        public BalanceFilter ValueGreaterThan(int value)
        {
            _valueGt = value;
            return this;
        }

        public BalanceFilter ValueGreaterThanOrEqual(int value)
        {
            _valueGte = value;
            return this;
        }

        public BalanceFilter ValueLessThan(int value)
        {
            _valueLt = value;
            return this;
        }

        public BalanceFilter ValueLessThanOrEqual(int value)
        {
            _valueLte = value;
            return this;
        }

        public BalanceFilter Wallet(string wallet)
        {
            _wallet = wallet;
            return this;
        }

        public BalanceFilter WalletIn(params string[] wallets)
        {
            _walletIn = wallets.ToList();
            return this;
        }
    }
}
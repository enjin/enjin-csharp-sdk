using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a filter input for balance queries.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.GetBalances"/>
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
        
        /// <summary>
        /// Sets the token (item) ID to filter for.
        /// </summary>
        /// <param name="tokenId">The token ID.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter TokenId(string tokenId)
        {
            _tokenId = tokenId;
            return this;
        }

        /// <summary>
        /// Sets the token (item) IDs to filter for.
        /// </summary>
        /// <param name="tokenIds">The token IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter TokenIdIn(params string[] tokenIds)
        {
            _tokenIdIn = tokenIds.ToList();
            return this;
        }
        
        /// <summary>
        /// Sets the filter to include balances equal to the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter Value(int value)
        {
            _value = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include balances greater than the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter ValueGreaterThan(int value)
        {
            _valueGt = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include balances greater than or equal to the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter ValueGreaterThanOrEqual(int value)
        {
            _valueGte = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include balances less than the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter ValueLessThan(int value)
        {
            _valueLt = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include balances less than or equal to the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter ValueLessThanOrEqual(int value)
        {
            _valueLte = value;
            return this;
        }

        /// <summary>
        /// Sets the wallet to filter for.
        /// </summary>
        /// <param name="wallet">The wallet address.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter Wallet(string wallet)
        {
            _wallet = wallet;
            return this;
        }

        /// <summary>
        /// Sets the wallets to filter for.
        /// </summary>
        /// <param name="wallets">The wallet addresses.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter WalletIn(params string[] wallets)
        {
            _walletIn = wallets.ToList();
            return this;
        }
    }
}
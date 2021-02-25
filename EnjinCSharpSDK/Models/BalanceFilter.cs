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
        [JsonProperty("assetId")]
        private string _assetId;
        [JsonProperty("assetId_in")]
        private List<string>? _assetIdIn;
        [JsonProperty("wallet")]
        private string _wallet;
        [JsonProperty("wallet_in")]
        private List<string>? _walletIn;
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
        /// Sets the asset ID to filter for.
        /// </summary>
        /// <param name="assetId">The asset ID.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter AssetId(string assetId)
        {
            _assetId = assetId;
            return this;
        }

        /// <summary>
        /// Sets the asset IDs to filter for.
        /// </summary>
        /// <param name="assetIds">The asset IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public BalanceFilter AssetIdIn(params string[]? assetIds)
        {
            _assetIdIn = assetIds?.ToList();
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
        public BalanceFilter WalletIn(params string[]? wallets)
        {
            _walletIn = wallets?.ToList();
            return this;
        }
    }
}
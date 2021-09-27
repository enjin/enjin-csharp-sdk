/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a filter input for transaction queries.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.GetRequests"/>
    [PublicAPI]
    public class TransactionFilter: Filter<TransactionFilter>
    {
        [JsonProperty("id")]
        private string? _id;
        
        [JsonProperty("id_in")]
        private List<string>? _idIn;

        [JsonProperty("transactionId")]
        private string? _transactionId;

        [JsonProperty("transactionId_in")]
        private List<string>? _transactionIdIn;

        [JsonProperty("assetId")]
        private string? _assetId;

        [JsonProperty("assetId_in")]
        private List<string>? _assetIdIn;

        [JsonProperty("type")]
        private RequestType? _type;

        [JsonProperty("type_in")]
        private List<RequestType>? _typeIn;

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

        [JsonProperty("state")]
        private RequestState? _state;

        [JsonProperty("state_in")]
        private List<RequestState>? _stateIn;
        
        [JsonProperty("wallet")]
        private string? _wallet;

        [JsonProperty("wallet_in")]
        private List<string>? _walletIn;
        
        /// <summary>
        /// Sets the ID to filter for.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter Id(string? id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        /// Sets the IDs to filter for.
        /// </summary>
        /// <param name="ids">The IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter IdIn(params string[]? ids)
        {
            _idIn = ids?.ToList();
            return this;
        }
        
        /// <summary>
        /// Sets the hash ID to filter for.
        /// </summary>
        /// <param name="transactionId">The hash ID.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter TransactionId(string? transactionId)
        {
            _transactionId = transactionId;
            return this;
        }

        /// <summary>
        /// Sets the hash IDs to filter for.
        /// </summary>
        /// <param name="transactionIds">The hash IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter TransactionIdIn(params string[]? transactionIds)
        {
            _transactionIdIn = transactionIds?.ToList();
            return this;
        }
        
        /// <summary>
        /// Sets the asset ID to filter for.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter AssetId(string? assetId)
        {
            _assetId = assetId;
            return this;
        }

        /// <summary>
        /// Sets the asset IDs to filter for.
        /// </summary>
        /// <param name="assetIds">The IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter AssetIdIn(params string[]? assetIds)
        {
            _assetIdIn = assetIds?.ToList();
            return this;
        }
        
        /// <summary>
        /// Sets the transaction type to filter for.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter Type(RequestType? type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        /// Sets the transaction types to filter for.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter Types(params RequestType[]? types)
        {
            _typeIn = types?.ToList();
            return this;
        }
        
        /// <summary>
        /// Sets the filter to include transactions equal to the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter Value(int? value)
        {
            _value = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include transactions greater than the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter ValueGreaterThan(int? value)
        {
            _valueGt = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include transactions greater than or equal the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter ValueGreaterThanOrEqual(int? value)
        {
            _valueGte = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include transactions less than the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter ValueLessThan(int? value)
        {
            _valueLt = value;
            return this;
        }

        /// <summary>
        /// Sets the filter to include transactions less than or equal the passed value.
        /// </summary>
        /// <param name="value">The value to compare by.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter ValueLessThanOrEqual(int? value)
        {
            _valueLte = value;
            return this;
        }
        
        /// <summary>
        /// Sets the transaction state to filter for.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter State(RequestState? state)
        {
            _state = state;
            return this;
        }

        /// <summary>
        /// Sets the transaction states to filter for.
        /// </summary>
        /// <param name="states">The states.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter StateIn(params RequestState[]? states)
        {
            _stateIn = states?.ToList();
            return this;
        }
        
        /// <summary>
        /// Sets the wallet to filter for.
        /// </summary>
        /// <param name="wallet">The wallet address.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter Wallet(string? wallet)
        {
            _wallet = wallet;
            return this;
        }

        /// <summary>
        /// Sets the wallets to filter for.
        /// </summary>
        /// <param name="wallets">The wallet addresses.</param>
        /// <returns>This filter for chaining.</returns>
        public TransactionFilter WalletIn(params string[]? wallets)
        {
            _walletIn = wallets?.ToList();
            return this;
        }
    }
}
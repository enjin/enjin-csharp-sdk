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
using Enjin.SDK.Shared;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a filter input for asset queries.
    /// </summary>
    /// <seealso cref="GetAssets"/>
    [PublicAPI]
    public class AssetFilter: Filter<AssetFilter>
    {
        [JsonProperty("id")]
        private string? _id;

        [JsonProperty("id_in")]
        private List<string>? _idIn;

        [JsonProperty("name")]
        private string? _name;

        [JsonProperty("name_contains")]
        private string? _nameContains;

        [JsonProperty("name_in")]
        private List<string>? _nameIn;

        [JsonProperty("name_starts_with")]
        private string? _nameStartsWith;

        [JsonProperty("name_ends_with")]
        private string? _nameEndsWith;

        [JsonProperty("wallet")]
        private string? _wallet;

        [JsonProperty("wallet_in")]
        private List<string>? _walletIn;

        /// <summary>
        /// Sets the asset ID to filter for.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter Id(string? id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        /// Sets the asset IDs to filter for.
        /// </summary>
        /// <param name="ids">The IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter IdIn(params string[]? ids)
        {
            _idIn = ids?.ToList();
            return this;
        }

        /// <summary>
        /// Sets the name to filter for.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter Name(string? name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// Sets the filter to include assets with names that include the passed string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter NameContains(string? text)
        {
            _nameContains = text;
            return this;
        }

        /// <summary>
        /// Sets the names to filter for.
        /// </summary>
        /// <param name="names">The names.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter NameIn(params string[]? names)
        {
            _nameIn = names?.ToList();
            return this;
        }

        /// <summary>
        /// Sets the filter to include assets with names which start with the passed string.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter NameStartsWith(string? prefix)
        {
            _nameStartsWith = prefix;
            return this;
        }

        /// <summary>
        /// Sets the filter to include assets with names which end with the passed string.
        /// </summary>
        /// <param name="suffix">The suffix.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter NameEndsWith(string? suffix)
        {
            _nameEndsWith = suffix;
            return this;
        }

        /// <summary>
        /// Sets the wallet to filter for.
        /// </summary>
        /// <param name="wallet">The wallet address.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter Wallet(string? wallet)
        {
            _wallet = wallet;
            return this;
        }

        /// <summary>
        /// Sets the wallets to filter for.
        /// </summary>
        /// <param name="addresses">The wallet addresses.</param>
        /// <returns>This filter for chaining.</returns>
        public AssetFilter WalletIn(params string[]? addresses)
        {
            _walletIn = addresses?.ToList();
            return this;
        }
    }
}
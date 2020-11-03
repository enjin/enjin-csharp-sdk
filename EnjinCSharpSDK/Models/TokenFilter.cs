using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a filter input for token queries.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.GetTokens"/>
    [PublicAPI]
    public class TokenFilter: Filter<TokenFilter>
    {
        [JsonProperty("id")]
        private string _id;

        [JsonProperty("id_in")]
        private List<string>? _idIn;

        [JsonProperty("name")]
        private string _name;

        [JsonProperty("name_contains")]
        private string _nameContains;

        [JsonProperty("name_in")]
        private List<string>? _nameIn;

        [JsonProperty("name_starts_with")]
        private string _nameStartsWith;

        [JsonProperty("name_ends_with")]
        private string _nameEndsWith;

        [JsonProperty("wallet")]
        private string _wallet;

        [JsonProperty("wallet_in")]
        private List<string>? _walletIn;

        /// <summary>
        /// Sets the token (item) ID to filter for.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter Id(string id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        /// Sets the token (item) IDs to filter for.
        /// </summary>
        /// <param name="ids">The IDs.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter IdIn(params string[]? ids)
        {
            _idIn = ids?.ToList();
            return this;
        }

        /// <summary>
        /// Sets the name to filter for.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter Name(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// Sets the filter to include items with names that include the passed string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter NameContains(string text)
        {
            _nameContains = text;
            return this;
        }

        /// <summary>
        /// Sets the names to filter for.
        /// </summary>
        /// <param name="names">The names.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter NameIn(params string[]? names)
        {
            _nameIn = names?.ToList();
            return this;
        }

        /// <summary>
        /// Sets the filter to include items with names which start with the passed string.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter NameStartsWith(string prefix)
        {
            _nameStartsWith = prefix;
            return this;
        }

        /// <summary>
        /// Sets the filter to include items with names which end with the passed string.
        /// </summary>
        /// <param name="suffix">The suffix.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter NameEndsWith(string suffix)
        {
            _nameEndsWith = suffix;
            return this;
        }

        /// <summary>
        /// Sets the wallet to filter for.
        /// </summary>
        /// <param name="wallet">The wallet address.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter Wallet(string wallet)
        {
            _wallet = wallet;
            return this;
        }

        /// <summary>
        /// Sets the wallets to filter for.
        /// </summary>
        /// <param name="addresses">The wallet addresses.</param>
        /// <returns>This filter for chaining.</returns>
        public TokenFilter WalletIn(params string[]? addresses)
        {
            _walletIn = addresses?.ToList();
            return this;
        }
    }
}
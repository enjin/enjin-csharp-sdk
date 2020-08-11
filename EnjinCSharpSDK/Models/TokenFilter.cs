using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TokenFilter: Filter<TokenFilter>
    {
        [JsonProperty("id")]
        private string _id;

        [JsonProperty("id_in")]
        private List<string> _idIn;

        [JsonProperty("name")]
        private string _name;

        [JsonProperty("name_contains")]
        private string _nameContains;

        [JsonProperty("name_in")]
        private List<string> _nameIn;

        [JsonProperty("name_starts_with")]
        private string _nameStartsWith;

        [JsonProperty("name_ends_with")]
        private string _nameEndsWith;

        [JsonProperty("wallet")]
        private string _wallet;

        [JsonProperty("wallet_in")]
        private List<string> _walletIn;

        public TokenFilter Id(string id)
        {
            _id = id;
            return this;
        }

        public TokenFilter IdIn(params string[] ids)
        {
            _idIn = ids.ToList();
            return this;
        }

        public TokenFilter Name(string name)
        {
            _name = name;
            return this;
        }

        public TokenFilter NameContains(string text)
        {
            _nameContains = text;
            return this;
        }

        public TokenFilter NameIn(params string[] names)
        {
            _nameIn = names.ToList();
            return this;
        }

        public TokenFilter NameStartsWith(string prefix)
        {
            _nameStartsWith = prefix;
            return this;
        }

        public TokenFilter NameEndsWith(string suffix)
        {
            _nameEndsWith = suffix;
            return this;
        }

        public TokenFilter Wallet(string wallet)
        {
            _wallet = wallet;
            return this;
        }

        public TokenFilter WalletIn(params string[] addresses)
        {
            _walletIn = addresses.ToList();
            return this;
        }
    }
}
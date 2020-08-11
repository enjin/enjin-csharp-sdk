using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class PlayerFilter: Filter<PlayerFilter>
    {
        [JsonProperty("id")]
        private string _id;
        [JsonProperty("id_in")]
        private List<string> _idIn;

        public PlayerFilter Id(string id)
        {
            _id = id;
            return this;
        }

        public PlayerFilter IdIn(params string[] ids)
        {
            _idIn = ids.ToList();
            return this;
        }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class PlayerFilter
    {
        [JsonProperty("id")]
        private string _id;
        [JsonProperty("id_in")]
        private List<string> _idIn;
        [JsonProperty("and")]
        private List<PlayerFilter> _and;
        [JsonProperty("or")]
        private List<PlayerFilter> _or;

        public PlayerFilter Id(string id)
        {
            _id = id;
            return this;
        }

        public PlayerFilter IdIn(List<string> ids)
        {
            _idIn = ids;
            return this;
        }

        public PlayerFilter And(List<PlayerFilter> others)
        {
            _and = others;
            return this;
        }
        
        public PlayerFilter Or(List<PlayerFilter> others)
        {
            _or = others;
            return this;
        }
    }
}
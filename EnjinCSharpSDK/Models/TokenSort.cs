using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TokenSort
    {
        [JsonProperty("field")]
        private TokenField _field;
        [JsonProperty("direction")]
        private SortDirection _direction;

        public TokenSort Field(TokenField field)
        {
            _field = field;
            return this;
        }

        public TokenSort Direction(SortDirection direction)
        {
            _direction = direction;
            return this;
        }
    }
}
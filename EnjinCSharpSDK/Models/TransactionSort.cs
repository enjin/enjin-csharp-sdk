using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TransactionSort
    {
        [JsonProperty("field")]
        private TransactionField _field;
        [JsonProperty("direction")]
        private SortDirection _direction;

        public TransactionSort Field(TransactionField field)
        {
            _field = field;
            return this;
        }

        public TransactionSort Direction(SortDirection direction)
        {
            _direction = direction;
            return this;
        }
    }
}
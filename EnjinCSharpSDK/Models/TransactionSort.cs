using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models sorting input for transactions.
    /// </summary>
    [PublicAPI]
    public class TransactionSort
    {
        [JsonProperty("field")]
        private TransactionField? _field;
        [JsonProperty("direction")]
        private SortDirection? _direction;

        /// <summary>
        /// Sets the field to sort by.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>This input for chaining.</returns>
        public TransactionSort Field(TransactionField? field)
        {
            _field = field;
            return this;
        }

        /// <summary>
        /// Sets the direction to sort by.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>This input for chaining.</returns>
        public TransactionSort Direction(SortDirection? direction)
        {
            _direction = direction;
            return this;
        }
    }
}
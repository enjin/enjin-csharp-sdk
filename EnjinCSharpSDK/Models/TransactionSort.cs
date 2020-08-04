using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TransactionSort
    {
        private TransactionField _field;
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
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class TokenSort
    {
        private TokenField _field;
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
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The operator type for filters.
    /// </summary>
    [PublicAPI]
    public enum Operator
    {
        GREATER_THAN,
        GREATER_THAN_OR_EQUAL,
        LESS_THAN,
        LESS_THAN_OR_EQUAL,
    }
}
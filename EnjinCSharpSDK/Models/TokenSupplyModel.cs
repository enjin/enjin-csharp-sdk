using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum TokenSupplyModel
    {
        FIXED,
        SETTABLE,
        INFINITE,
        COLLAPSING,
        ANNUAL_VALUE,
        ANNUAL_PERCENTAGE
    }
}
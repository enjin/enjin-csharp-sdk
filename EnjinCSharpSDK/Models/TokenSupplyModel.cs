using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the token supply model.
    /// </summary>
    /// <seealso cref="Token"/>
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
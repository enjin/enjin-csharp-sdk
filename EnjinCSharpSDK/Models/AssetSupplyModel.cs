using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Values used to specify the asset supply model.
    /// </summary>
    /// <seealso cref="Asset"/>
    [PublicAPI]
    public enum AssetSupplyModel
    {
        FIXED,
        SETTABLE,
        INFINITE,
        COLLAPSING,
        ANNUAL_VALUE,
        ANNUAL_PERCENTAGE
    }
}
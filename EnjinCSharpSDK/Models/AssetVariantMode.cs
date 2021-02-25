using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the mode that determines variant behaviour.
    /// </summary>
    /// <seealso cref="Asset"/>
    [PublicAPI]
    public enum AssetVariantMode
    {
        NONE,
        BEAM,
        ONCE,
        ALWAYS
    }
}
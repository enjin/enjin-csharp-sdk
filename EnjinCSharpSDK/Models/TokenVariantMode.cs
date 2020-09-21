using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the mode that determines variant behaviour.
    /// </summary>
    /// <seealso cref="Token"/>
    [PublicAPI]
    public enum TokenVariantMode
    {
        NONE,
        BEAM,
        ONCE,
        ALWAYS
    }
}
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The transferable type.
    /// </summary>
    /// <seealso cref="Token"/>
    [PublicAPI]
    public enum TokenTransferable
    {
        PERMANENT,
        TEMPORARY,
        BOUND
    }
}
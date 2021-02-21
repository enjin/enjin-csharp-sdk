using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// The transferable type.
    /// </summary>
    /// <seealso cref="Asset"/>
    [PublicAPI]
    public enum AssetTransferable
    {
        PERMANENT,
        TEMPORARY,
        BOUND
    }
}
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the transfer fee type.
    /// </summary>
    /// <seealso cref="AssetTransferFeeSettings"/>
    [PublicAPI]
    public enum AssetTransferFeeType
    {
        NONE,
        PER_TRANSFER,
        PER_CRYPTO_ITEM,
        RATIO_CUT,
        RATIO_EXTRA
    }
}
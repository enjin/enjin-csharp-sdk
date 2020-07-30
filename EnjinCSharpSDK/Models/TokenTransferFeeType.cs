using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum TokenTransferFeeType
    {
        NONE,
        PER_TRANSFER,
        PER_CRYPTO_ITEM,
        RATIO_CUT,
        RATIO_EXTRA
    }
}
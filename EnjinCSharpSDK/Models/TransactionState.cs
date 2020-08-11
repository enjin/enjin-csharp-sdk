using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public enum TransactionState
    {
        PENDING,
        BROADCAST,
        TP_PROCESSING,
        EXECUTED,
        CANCELED_USER,
        CANCELED_PLATFORM,
        DROPPED,
        FAILED
    }
}
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the state of a request.
    /// </summary>
    /// <seealso cref="Request"/>
    [PublicAPI]
    public enum RequestState
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
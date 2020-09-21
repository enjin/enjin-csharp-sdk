using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    /// <summary>
    /// Event listener interface for notifications from the platform.
    /// </summary>
    /// <seealso cref="IEventService"/>
    [PublicAPI]
    public interface IEventListener
    {
        /// <summary>
        /// Called when an event is received.
        /// </summary>
        /// <param name="notificationEvent">The event received.</param>
        void NotificationReceived(NotificationEvent notificationEvent);
    }
}
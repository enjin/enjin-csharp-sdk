using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    [PublicAPI]
    public interface IEventListener
    {
        void NotificationReceived(NotificationEvent notificationEvent);
    }
}
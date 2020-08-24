using System.Linq;
using Enjin.SDK.Models;
using Enjin.SDK.Utils;
using PusherClient;

namespace Enjin.SDK.Events
{
    internal class PusherEventListener
    {
        private readonly PusherEventService _service;

        public PusherEventListener(PusherEventService service)
        {
            _service = service;
        }

        public void OnEvent(PusherEvent pusherEvent)
        {
            string eventName = pusherEvent.EventName;
            string channelName = pusherEvent.ChannelName;
            string data = pusherEvent.Data;

            Call(eventName, channelName, data);
        }

        private void Call(string @event, string channel, string data)
        {
            if (_service.RegisteredListeners.Count == 0)
            {
                // TODO: Log that there are no registered listeners.
                return;
            }

            var def = EventTypeDef.GetFromKey(@event);

            if (def.Type == EventType.UNKNOWN)
            {
                // TODO: Log that an unknown event type was encountered.
                return;
            }

            NotificationEvent notificationEvent = new NotificationEvent(def.Type, channel, data);

            _service.RegisteredListeners
                    .Where(r => r.Matcher(def.Type))
                    .Do(r => r.Listener.NotificationReceived(notificationEvent));
        }
    }
}
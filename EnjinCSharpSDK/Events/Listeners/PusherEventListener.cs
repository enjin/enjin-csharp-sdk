using System.Linq;
using System.Runtime.CompilerServices;
using Enjin.SDK.Models;
using Enjin.SDK.Utils;
using PusherClient;

[assembly: InternalsVisibleTo("TestSuite")]

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
                _service.LoggerProvider.Log(LogLevel.INFO, "No registered listeners when event was received.");
                return;
            }

            var def = EventTypeDef.GetFromKey(@event);
            if (def.Type == EventType.UNKNOWN)
            {
                _service.LoggerProvider.Log(LogLevel.WARN, $"Unknown event type for key \"{@event}\".");
                return;
            }

            NotificationEvent notificationEvent = new NotificationEvent(def.Type, channel, data);

            _service.RegisteredListeners
                    .Where(r => r.Matcher(def.Type))
                    .Do(r => r.Listener.NotificationReceived(notificationEvent));
        }
    }
}
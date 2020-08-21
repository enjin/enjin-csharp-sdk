using System.Linq;
using Enjin.SDK.Models;
using PusherClient;

namespace Enjin.SDK.Events
{
    internal class PusherEventListener
    {
        private readonly PusherEventService _service;

        internal PusherEventListener(PusherEventService service)
        {
            _service = service;
        }
        
        internal void OnEvent(PusherEvent pusherEvent)
        {
            string eventName = pusherEvent.EventName;
            string channelName = pusherEvent.ChannelName;
            string data = pusherEvent.Data;
            
            Call(eventName, channelName, data);
        }

        private void Call(string eventName, string channelName, string data)
        {
            if (_service.RegisteredListeners.Count == 0)
            {
                // TODO: Log that there are no registered listeners.
                return;
            }

            var eventType = EventType.Values()
                                     .FirstOrDefault(type => type.Type.Equals(eventName));

            if (eventType == null)
            {
                // TODO: Log that an unknown event type was encountered.
                return;
            }

            NotificationEvent notificationEvent = NotificationEvent.Builder()
                                                                   .Type(eventType)
                                                                   .Channel(channelName)
                                                                   .Data(data)
                                                                   .Build();

            foreach (var registration in _service.RegisteredListeners
                                                 .Where(registration => registration.Matcher(eventType)))
                registration.Listener.NotificationReceived(notificationEvent);
        }
    }
}
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public sealed class NotificationEvent
    {
        public EventType? Type { get; private set; }
        
        public string? Channel { get; private set; }
        
        public string? Data { get; private set; }

        public JsonToken EventData => _lazyEventData.Value;

        private readonly Lazy<JsonToken> _lazyEventData;
        
        private NotificationEvent()
        {
            _lazyEventData = new Lazy<JsonToken>(CreateEventData);
        }

        internal static NotificationEventBuilder Builder() => new NotificationEventBuilder();

        private JsonToken CreateEventData()
        {
            return JsonConvert.DeserializeObject<JsonToken>(Data ?? throw new InvalidOperationException());
        }

        internal class NotificationEventBuilder
        {
            private EventType? _type;
            private string? _channel;
            private string? _data;

            public NotificationEventBuilder Type(EventType type)
            {
                _type = type;
                return this;
            }

            public NotificationEventBuilder Channel(string channel)
            {
                _channel = channel;
                return this;
            }

            public NotificationEventBuilder Data(string data)
            {
                _data = data;
                return this;
            }
            
            public NotificationEvent Build()
            {
                return new NotificationEvent
                {
                    Type = _type,
                    Channel = _channel,
                    Data = _data
                };
            }
        }
    }
}
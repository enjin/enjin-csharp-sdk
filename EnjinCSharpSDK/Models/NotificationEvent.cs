using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public sealed class NotificationEvent
    {
        public EventType Type { get; private set; }

        public string Channel { get; private set; } = null!;

        public string Message { get; private set; } = null!;

        public JsonToken Data => _data.Value;

        private readonly Lazy<JsonToken> _data;

        private NotificationEvent()
        {
            _data = new Lazy<JsonToken>(CreateEventData);
        }

        private JsonToken CreateEventData()
        {
            if (Message == null)
                throw new InvalidOperationException("Cannot deserialize null message");
            return JsonConvert.DeserializeObject<JsonToken>(Message);
        }

        internal static NotificationEventBuilder Builder() => new NotificationEventBuilder();
        
        internal class NotificationEventBuilder
        {
            private EventType? _type;
            private string? _channel;
            private string? _message;

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

            public NotificationEventBuilder Message(string message)
            {
                _message = message;
                return this;
            }

            public NotificationEvent Build()
            {
                return new NotificationEvent
                {
                    Type = _type ?? throw new InvalidOperationException("Type must be set"),
                    Channel = _channel ?? throw new InvalidOperationException("Channel must be set"),
                    Message = _message ?? throw new InvalidOperationException("Message must be set")
                };
            }
        }
    }
}
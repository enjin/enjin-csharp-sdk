using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public sealed class NotificationEvent
    {
        public EventType Type { get; }

        public string Channel { get; }

        public string Message { get; }

        public JsonToken Data => _data.Value;

        private readonly Lazy<JsonToken> _data;

        internal NotificationEvent(EventType type, string channel, string message)
        {
            Type = type;
            Channel = channel ?? throw new ArgumentNullException(nameof(channel));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            _data = new Lazy<JsonToken>(CreateEventData);
        }

        private JsonToken CreateEventData()
        {
            if (Message == null)
                throw new InvalidOperationException("Cannot deserialize null message");
            return JsonConvert.DeserializeObject<JsonToken>(Message);
        }
    }
}
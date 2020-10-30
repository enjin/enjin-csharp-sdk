using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Models
{
    /// <summary>
    /// Container class for notification data from the platform.
    /// </summary>
    /// <seealso cref="EventType"/>
    /// <seealso cref="Enjin.SDK.Events.IEventService"/>
    [PublicAPI]
    public sealed class NotificationEvent
    {
        /// <summary>
        /// Represents the type of the event.
        /// </summary>
        /// <value>The event type.</value>
        public EventType Type { get; }

        /// <summary>
        /// Represents the channel the notification was broadcast on.
        /// </summary>
        /// <value>The channel.</value>
        public string Channel { get; }

        /// <summary>
        /// Represents the raw data of the notification.
        /// </summary>
        /// <value>The raw data.</value>
        public string Message { get; }

        /// <summary>
        /// Represents the deserialized data of the notification.
        /// </summary>
        /// <value>The data (lazy loaded).</value>
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
/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public JObject Data => _data.Value;

        private readonly Lazy<JObject> _data;

        internal NotificationEvent(EventType type, string channel, string message)
        {
            Type = type;
            Channel = channel ?? throw new ArgumentNullException(nameof(channel));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            _data = new Lazy<JObject>(CreateEventData);
        }

        private JObject CreateEventData()
        {
            if (Message == null)
                throw new InvalidOperationException("Cannot deserialize null message");
            return JsonConvert.DeserializeObject<JObject>(Message);
        }
    }
}
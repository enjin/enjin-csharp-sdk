using System;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    /// <summary>
    /// Specifies the events to be allowed or ignored for a listener.
    /// </summary>
    /// <seealso cref="IEventListener"/>
    /// <seealso cref="IEventService"/>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class EventFilter : Attribute
    {
        /// <summary>
        /// Represents if the events are to be allowed (<c>true</c>) or ignored (<c>false</c>).
        /// </summary>
        /// <value>The state.</value>
        public bool Allowed { get; }
        
        /// <summary>
        /// Represents the events to be filtered and allowed or ignored based on <see cref="Allowed"/>.
        /// </summary>
        /// <value>The event types.</value>
        public EventType[] Types { get; }

        /// <summary>
        /// Constructs the attribute.
        /// </summary>
        /// <param name="allowed">If the events are allowed.</param>
        /// <param name="types">The events being filtered.</param>
        public EventFilter(bool allowed, params EventType[] types)
        {
            Allowed = allowed;
            Types = types;
        }
    }
}
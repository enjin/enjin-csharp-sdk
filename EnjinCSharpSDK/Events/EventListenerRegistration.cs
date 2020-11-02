using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Enjin.SDK.Models;
using JetBrains.Annotations;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Events
{
    /// <summary>
    /// Registration wrapper for a <see cref="IEventListener"/> .
    /// </summary>
    /// <seealso cref="IEventListener"/>
    /// <seealso cref="IEventService"/>
    [PublicAPI]
    public sealed class EventListenerRegistration
    {
        /// <summary>
        /// A delegate that matches all event types.
        /// </summary>
        public static readonly Func<EventType, bool> ALLOW_ALL_MATCHER = type => true;

        /// <summary>
        /// Represents the listener this registration is for.
        /// </summary>
        /// <value>The listener.</value>
        public IEventListener Listener { get; }
        
        /// <summary>
        /// Represents the delegate event matcher for the <see cref="Listener"/> of this registration.
        /// </summary>
        /// <value>The delegate event matcher.</value>
        public Func<EventType, bool> Matcher { get; }

        internal EventListenerRegistration(IEventListener listener) : this(listener, ALLOW_ALL_MATCHER)
        {
        }

        internal EventListenerRegistration(IEventListener listener, Func<EventType, bool> matcher)
        {
            Listener = listener;
            Matcher = matcher;
        }

        internal static RegistrationListenerConfiguration Configure(IEventListener listener)
        {
            return new RegistrationListenerConfiguration(listener);
        }

        internal sealed class RegistrationListenerConfiguration
        {
            private readonly IEventListener _listener;
            private Func<EventType, bool> _matcher = ALLOW_ALL_MATCHER;

            internal RegistrationListenerConfiguration(IEventListener listener)
            {
                _listener = listener;
                DetectAndApplyListenerAttributes();
            }

            internal RegistrationListenerConfiguration WithMatcher(Func<EventType, bool> matcher)
            {
                _matcher = matcher;
                return this;
            }

            internal RegistrationListenerConfiguration WithAllowedEvents(params EventType[] types)
            {
                _matcher = type => types.Any(t => t == type);
                return this;
            }

            internal RegistrationListenerConfiguration WithIgnoredEvents(params EventType[] types)
            {
                _matcher = type => types.All(t => t != type);
                return this;
            }

            internal EventListenerRegistration Create() => new EventListenerRegistration(_listener, _matcher);

            private void DetectAndApplyListenerAttributes()
            {
                if (_listener == null)
                    return;

                EventFilter filter =
                    (EventFilter) Attribute.GetCustomAttribute(_listener.GetType(), typeof(EventFilter));
                if (filter == null)
                    return;

                if (filter.Allowed)
                    WithAllowedEvents(filter.Types);
                else
                    WithIgnoredEvents(filter.Types);
            }
        }
    }
}
using System;
using System.Linq;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    [PublicAPI]
    public sealed class EventListenerRegistration
    {
        public static readonly Func<EventType, bool> ALLOW_ALL_MATCHER = type => true;

        public IEventListener Listener { get; }
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
                _matcher = type => types.Any(t => t != type);
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
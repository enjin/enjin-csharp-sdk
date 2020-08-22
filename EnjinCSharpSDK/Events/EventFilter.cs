using System;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class EventFilter : Attribute
    {
        public bool Allowed { get; }
        public EventType[] Types { get; }

        public EventFilter(bool allowed, params EventType[] types)
        {
            Allowed = allowed;
            Types = types;
        }
    }
}
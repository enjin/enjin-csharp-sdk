using System;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    [PublicAPI]
    public interface IEventService
    {
        void Start();

        void Start(Platform platform);

        void Shutdown();
        
        bool IsConnected();

        EventListenerRegistration RegisterListener(IEventListener listener);
        
        EventListenerRegistration RegisterListenerWithMatcher(IEventListener listener, Func<EventType, bool> matcher);
        
        EventListenerRegistration RegisterListenerIncludingTypes(IEventListener listener, params EventType[] events);
        
        EventListenerRegistration RegisterListenerExcludingTypes(IEventListener listener, params EventType[] events);

        void UnregisterListener(IEventListener listener);

        void SubscribeToApp(int app);
        
        void UnsubscribeToApp(int app);

        bool IsSubscribedToApp(int app);
        
        void SubscribeToPlayer(int app, string player);
        
        void UnsubscribeToPlayer(int app, string player);
        
        bool IsSubscribedToPlayer(int app, string player);
        
        void SubscribeToToken(string token);
        
        void UnsubscribeToToken(string token);
        
        bool IsSubscribedToToken(string token);
        
        void SubscribeToWallet(string wallet);
        
        void UnsubscribeToWallet(string wallet);
        
        bool IsSubscribedToWallet(string wallet);
    }
}
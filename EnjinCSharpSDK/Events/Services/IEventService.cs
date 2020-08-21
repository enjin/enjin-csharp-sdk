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
        
        EventListenerRegistration RegisterListenerIncludingTypes(IEventListener listener, params EventType[] allowed);
        
        EventListenerRegistration RegisterListenerExcludingTypes(IEventListener listener, params EventType[] ignored);

        void UnregisterListener(IEventListener listener);

        void SubscribeToApp(int appId);
        
        void UnsubscribeToApp(int appId);

        bool IsSubscribedToApp(int appId);
        
        void SubscribeToPlayer(int appId, string playerId);
        
        void UnsubscribeToPlayer(int appId, string playerId);
        
        bool IsSubscribedToPlayer(int appId, string playerId);
        
        void SubscribeToToken(string tokenId);
        
        void UnsubscribeToToken(string tokenId);
        
        bool IsSubscribedToToken(string tokenId);
        
        void SubscribeToWallet(string ethAddress);
        
        void UnsubscribeToWallet(string ethAddress);
        
        bool IsSubscribedToWallet(string ethAddress);
    }
}
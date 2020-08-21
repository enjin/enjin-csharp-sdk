using System;
using System.Collections.Generic;
using System.Linq;
using Enjin.SDK.Models;
using JetBrains.Annotations;
using PusherClient;
using static Enjin.SDK.Events.EventListenerRegistration;
using Pusher = PusherClient.Pusher;
using PusherOptions = PusherClient.PusherOptions;

namespace Enjin.SDK.Events
{
    [PublicAPI]
    public sealed class PusherEventService : IEventService
    {
        public Platform Platform { get; private set; }
        internal List<EventListenerRegistration> RegisteredListeners { get; } = new List<EventListenerRegistration>();
        private readonly Dictionary<string, Channel> _subscribed = new Dictionary<string, Channel>();
        private Pusher? _pusher;
        private PusherEventListener? _listener;

        public PusherEventService(Platform platform)
        {
            Platform = platform;
        }

        public void Start()
        {
            Shutdown();

            var notifications = Platform.Notifications;
            var pusher = notifications?.Pusher;
            var key = pusher?.Key;
            var cluster = pusher?.Options?.Cluster;
            var encrypted = pusher?.Options?.Encrypted;
            if (key == null || cluster == null || encrypted == null)
                return;
            
            PusherOptions options = new PusherOptions
            {
                Cluster = cluster,
                Encrypted = encrypted.Value
            };
            _pusher = new Pusher(key, options);
            _listener = new PusherEventListener(this);
            
            _pusher.Error += (sender, error) => { /* TODO: Log error. */ };
            _pusher.ConnectAsync();
        }

        public void Start(Platform platform)
        {
            Platform = platform;
            Start();
        }

        public void Shutdown() => _pusher?.DisconnectAsync();

        public bool IsConnected() => _pusher?.State == ConnectionState.Connected;

        public EventListenerRegistration RegisterListener(IEventListener listener) =>
            Register(ConfigureListener(listener));

        public EventListenerRegistration RegisterListenerWithMatcher(IEventListener listener,
                                                                     Func<EventType, bool> matcher) =>
            Register(ConfigureListener(listener).WithMatcher(matcher));

        public EventListenerRegistration RegisterListenerIncludingTypes(IEventListener listener,
                                                                        params EventType[] allowed) =>
            Register(ConfigureListener(listener).WithAllowedEvents(allowed));

        public EventListenerRegistration RegisterListenerExcludingTypes(IEventListener listener,
                                                                        params EventType[] ignored) =>
            Register(ConfigureListener(listener).WithIgnoredEvents(ignored));

        private RegistrationListenerConfiguration ConfigureListener(IEventListener listener) =>
            Configure(listener);

        private EventListenerRegistration Register(RegistrationListenerConfiguration configuration) =>
            configuration.Create();

        public void UnregisterListener(IEventListener listener)
        {
            EventListenerRegistration reg =
                RegisteredListeners.FirstOrDefault(registration => registration.Listener == listener);
            if (reg != null)
                RegisteredListeners.Remove(reg);
        }

        public void SubscribeToApp(int appId) =>
            Subscribe(new PusherAppChannel(Platform, appId).Channel());

        public void UnsubscribeToApp(int appId) =>
            Unsubscribe(new PusherAppChannel(Platform, appId).Channel());

        public bool IsSubscribedToApp(int appId) =>
            _subscribed.ContainsKey(new PusherAppChannel(Platform, appId).Channel());

        public void SubscribeToPlayer(int appId, string playerId) =>
            Subscribe(new PusherPlayerChannel(Platform, appId, playerId).Channel());

        public void UnsubscribeToPlayer(int appId, string playerId) =>
            Unsubscribe(new PusherPlayerChannel(Platform, appId, playerId).Channel());

        public bool IsSubscribedToPlayer(int appId, string playerId) =>
            _subscribed.ContainsKey(new PusherPlayerChannel(Platform, appId, playerId).Channel());

        public void SubscribeToToken(string tokenId) =>
            Subscribe(new PusherTokenChannel(Platform, tokenId).Channel());

        public void UnsubscribeToToken(string tokenId) =>
            Unsubscribe(new PusherTokenChannel(Platform, tokenId).Channel());

        public bool IsSubscribedToToken(string tokenId) =>
            _subscribed.ContainsKey(new PusherTokenChannel(Platform, tokenId).Channel());

        public void SubscribeToWallet(string ethAddress) =>
            Subscribe(new PusherWalletChannel(Platform, ethAddress).Channel());

        public void UnsubscribeToWallet(string ethAddress) =>
            Unsubscribe(new PusherWalletChannel(Platform, ethAddress).Channel());

        public bool IsSubscribedToWallet(string ethAddress) =>
            _subscribed.ContainsKey(new PusherWalletChannel(Platform, ethAddress).Channel());

        private void Subscribe(string channelName)
        {
            if (_pusher == null || _subscribed.ContainsKey(channelName))
                return;

            Channel pusherChannel = _pusher.SubscribeAsync(channelName).Result;
            Bind(pusherChannel);
            _subscribed.Add(channelName, pusherChannel);
        }

        private void Unsubscribe(string channelName)
        {
            if (_pusher == null || !_subscribed.ContainsKey(channelName))
                return;

            _subscribed[channelName].Unsubscribe();
            _subscribed.Remove(channelName);
        }

        private void Bind(Channel pusherChannel)
        {
            foreach (EventType eventType in EventType.FilterByChannelTypes(pusherChannel.Name))
                _pusher!.Bind(eventType.Type, _listener!.OnEvent);
        }
    }
}
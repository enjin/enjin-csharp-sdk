using System;
using System.Collections.Generic;
using System.Linq;
using Enjin.SDK.Models;
using Enjin.SDK.Utils;
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

            _pusher.Error += (sender, error) => { }; // TODO: Log error.
            _pusher.ConnectAsync();
        }

        public void Start(Platform platform)
        {
            Platform = platform;
            Start();
        }

        public void Shutdown() => _pusher?.DisconnectAsync();

        public bool IsConnected() => _pusher?.State == ConnectionState.Connected;

        public EventListenerRegistration RegisterListener(IEventListener listener)
        {
            return Register(ConfigureListener(listener));
        }

        public EventListenerRegistration RegisterListenerWithMatcher(IEventListener listener,
            Func<EventType, bool> matcher)
        {
            return Register(ConfigureListener(listener).WithMatcher(matcher));
        }

        public EventListenerRegistration RegisterListenerIncludingTypes(IEventListener listener,
            params EventType[] events)
        {
            return Register(ConfigureListener(listener).WithAllowedEvents(events));
        }

        public EventListenerRegistration RegisterListenerExcludingTypes(IEventListener listener,
            params EventType[] events)
        {
            return Register(ConfigureListener(listener).WithIgnoredEvents(events));
        }

        private RegistrationListenerConfiguration ConfigureListener(IEventListener listener)
        {
            return Configure(listener);
        }

        private EventListenerRegistration Register(RegistrationListenerConfiguration configuration)
        {
            return configuration.Create();
        }

        public void UnregisterListener(IEventListener listener)
        {
            EventListenerRegistration reg =
                RegisteredListeners.FirstOrDefault(r => r.Listener == listener);
            if (reg != null)
                RegisteredListeners.Remove(reg);
        }

        public void SubscribeToApp(int app)
        {
            Subscribe(new PusherAppChannel(Platform, app).Channel());
        }

        public void UnsubscribeToApp(int app)
        {
            Unsubscribe(new PusherAppChannel(Platform, app).Channel());
        }

        public bool IsSubscribedToApp(int app)
        {
            return _subscribed.ContainsKey(new PusherAppChannel(Platform, app).Channel());
        }

        public void SubscribeToPlayer(int app, string player)
        {
            Subscribe(new PusherPlayerChannel(Platform, app, player).Channel());
        }

        public void UnsubscribeToPlayer(int app, string player)
        {
            Unsubscribe(new PusherPlayerChannel(Platform, app, player).Channel());
        }

        public bool IsSubscribedToPlayer(int app, string player)
        {
            return _subscribed.ContainsKey(new PusherPlayerChannel(Platform, app, player).Channel());
        }

        public void SubscribeToToken(string token)
        {
            Subscribe(new PusherTokenChannel(Platform, token).Channel());
        }

        public void UnsubscribeToToken(string token)
        {
            Unsubscribe(new PusherTokenChannel(Platform, token).Channel());
        }

        public bool IsSubscribedToToken(string token)
        {
            return _subscribed.ContainsKey(new PusherTokenChannel(Platform, token).Channel());
        }

        public void SubscribeToWallet(string wallet)
        {
            Subscribe(new PusherWalletChannel(Platform, wallet).Channel());
        }

        public void UnsubscribeToWallet(string wallet)
        {
            Unsubscribe(new PusherWalletChannel(Platform, wallet).Channel());
        }

        public bool IsSubscribedToWallet(string wallet)
        {
            return _subscribed.ContainsKey(new PusherWalletChannel(Platform, wallet).Channel());
        }

        private void Subscribe(string channel)
        {
            if (_pusher == null || _subscribed.ContainsKey(channel))
                return;

            Channel pusherChannel = _pusher.SubscribeAsync(channel).Result;
            Bind(pusherChannel);
            _subscribed.Add(channel, pusherChannel);
        }

        private void Unsubscribe(string channel)
        {
            if (_pusher == null || !_subscribed.ContainsKey(channel))
                return;

            _subscribed[channel].Unsubscribe();
            _subscribed.Remove(channel);
        }

        private void Bind(Channel channel)
        {
            EventTypeDef.FilterByChannelTypes(channel.Name)
                        .Do(d => _pusher!.Bind(d.Key, _listener!.OnEvent));
        }
    }
}
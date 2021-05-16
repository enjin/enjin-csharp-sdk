using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Enjin.SDK.Models;
using Enjin.SDK.Utils;
using JetBrains.Annotations;
using PusherClient;
using static Enjin.SDK.Events.EventListenerRegistration;
using Pusher = PusherClient.Pusher;
using PusherOptions = PusherClient.PusherOptions;

[assembly: InternalsVisibleTo("TestSuite")]

namespace Enjin.SDK.Events
{
    /// <summary>
    /// Implementation of <see cref="IEventService"/> utilizing Pusher channel events.
    /// </summary>
    /// <seealso cref="IEventListener"/>
    [PublicAPI]
    public sealed class PusherEventService : IEventService
    {
        /// <summary>
        /// Represents the platform details this service is utilizing.
        /// </summary>
        /// <value>The platform details.</value>
        public Platform Platform { get; private set; }

        /// <summary>
        /// Represents the logger provider used by this service.
        /// </summary>
        /// <value>The logger provider.</value>
        public LoggerProvider LoggerProvider { get; private set; }

        /// <inheritdoc/>
        public event EventHandler? Connected;

        /// <inheritdoc/>
        public event EventHandler? Disconnected;

        /// <inheritdoc/>
        public event EventHandler<Exception>? Error;

        internal List<EventListenerRegistration> RegisteredListeners { get; } = new List<EventListenerRegistration>();
        private readonly Dictionary<string, Channel> _subscribed = new Dictionary<string, Channel>();
        private Pusher? _pusher;
        private PusherEventListener? _listener;

        /// <summary>
        /// Constructs the service and assigns the given platform details and a default logger provider. See
        /// <see cref="Start()"/> to start the service.
        /// </summary>
        /// <param name="platform">The platform details.</param>
        public PusherEventService(Platform platform) : this(LoggerProvider.CreateDefaultLoggerProvider(), platform)
        {
        }

        /// <summary>
        /// Constructs the event service and assigns the given logger provider and platform details. See
        /// <see cref="Start()"/> to start the service.
        /// </summary>
        /// <param name="loggerProvider"></param>
        /// <param name="platform"></param>
        public PusherEventService(LoggerProvider loggerProvider, Platform platform)
        {
            LoggerProvider = loggerProvider;
            Platform = platform;
        }

        /// <inheritdoc/>
        public Task Start()
        {
            Shutdown();

            var notifications = Platform.Notifications;
            var pusher = notifications?.Pusher;
            var key = pusher?.Key;
            var cluster = pusher?.Options?.Cluster;
            var encrypted = pusher?.Options?.Encrypted;
            if (key == null || cluster == null || encrypted == null)
                return Task.FromException(new InvalidOperationException("Platform has null data for 'key', 'cluster', or 'encrypted'."));

            PusherOptions options = new PusherOptions
            {
                Cluster = cluster,
                Encrypted = encrypted.Value
            };
            _pusher = new Pusher(key, options);
            _listener = new PusherEventListener(this);

            // Subscribe to events
            _pusher.Connected += sender => { Connected?.Invoke(this, EventArgs.Empty); };
            _pusher.Disconnected += sender => { Disconnected?.Invoke(this, EventArgs.Empty); };
            _pusher.Error += (sender, error) =>
            {
                LoggerProvider.Log(LogLevel.SEVERE, "Error on Pusher client: ", error);
                Error?.Invoke(this, error);
            };

            return _pusher.ConnectAsync();
        }

        /// <inheritdoc/>
        public Task Start(Platform platform)
        {
            Platform = platform;
            return Start();
        }

        /// <inheritdoc/>
        public Task Shutdown()
        {
            return _pusher?.DisconnectAsync() ?? Task.FromException(new InvalidOperationException("Event service has not been started."));
        }

        /// <inheritdoc/>
        public bool IsConnected()
        {
            return _pusher?.State == ConnectionState.Connected;
        }

        /// <inheritdoc/>
        public EventListenerRegistration RegisterListener(IEventListener listener)
        {
            return Register(ConfigureListener(listener));
        }

        /// <inheritdoc/>
        public EventListenerRegistration RegisterListenerWithMatcher(IEventListener listener,
                                                                     Func<EventType, bool> matcher)
        {
            return Register(ConfigureListener(listener).WithMatcher(matcher));
        }

        /// <inheritdoc/>
        public EventListenerRegistration RegisterListenerIncludingTypes(IEventListener listener,
                                                                        params EventType[] events)
        {
            return Register(ConfigureListener(listener).WithAllowedEvents(events));
        }

        /// <inheritdoc/>
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
            // Checks if listener is already registered
            foreach (var r in RegisteredListeners.Where(r => r.Listener.Equals(configuration.Listener)))
            {
                return r;
            }

            var config = configuration.Create();
            RegisteredListeners.Add(config);
            return config;
        }

        /// <inheritdoc/>
        public void UnregisterListener(IEventListener listener)
        {
            var reg = RegisteredListeners.FirstOrDefault(r => r.Listener == listener);
            if (reg != null)
                RegisteredListeners.Remove(reg);
        }

        /// <inheritdoc/>
        public void SubscribeToProject(int project)
        {
            Subscribe(new ProjectChannel(Platform, project).Channel());
        }

        /// <inheritdoc/>
        public void UnsubscribeToProject(int project)
        {
            Unsubscribe(new ProjectChannel(Platform, project).Channel());
        }

        /// <inheritdoc/>
        public bool IsSubscribedToProject(int project)
        {
            return _subscribed.ContainsKey(new ProjectChannel(Platform, project).Channel());
        }

        /// <inheritdoc/>
        public void SubscribeToPlayer(int project, string player)
        {
            Subscribe(new PlayerChannel(Platform, project, player).Channel());
        }

        /// <inheritdoc/>
        public void UnsubscribeToPlayer(int project, string player)
        {
            Unsubscribe(new PlayerChannel(Platform, project, player).Channel());
        }

        /// <inheritdoc/>
        public bool IsSubscribedToPlayer(int project, string player)
        {
            return _subscribed.ContainsKey(new PlayerChannel(Platform, project, player).Channel());
        }

        /// <inheritdoc/>
        public void SubscribeToAsset(string asset)
        {
            Subscribe(new AssetChannel(Platform, asset).Channel());
        }

        /// <inheritdoc/>
        public void UnsubscribeToAsset(string asset)
        {
            Unsubscribe(new AssetChannel(Platform, asset).Channel());
        }

        /// <inheritdoc/>
        public bool IsSubscribedToAsset(string asset)
        {
            return _subscribed.ContainsKey(new AssetChannel(Platform, asset).Channel());
        }

        /// <inheritdoc/>
        public void SubscribeToWallet(string wallet)
        {
            Subscribe(new WalletChannel(Platform, wallet).Channel());
        }

        /// <inheritdoc/>
        public void UnsubscribeToWallet(string wallet)
        {
            Unsubscribe(new WalletChannel(Platform, wallet).Channel());
        }

        /// <inheritdoc/>
        public bool IsSubscribedToWallet(string wallet)
        {
            return _subscribed.ContainsKey(new WalletChannel(Platform, wallet).Channel());
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
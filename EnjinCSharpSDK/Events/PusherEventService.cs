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

        private readonly HashSet<string> _subscribed = new HashSet<string>();

        private Pusher? _pusher;
        private readonly PusherEventListener _listener;

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
            _listener = new PusherEventListener(this);
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

            // Subscribe to events
            _pusher.Connected += sender => { Connected?.Invoke(this, EventArgs.Empty); };
            _pusher.Disconnected += sender => { Disconnected?.Invoke(this, EventArgs.Empty); };
            _pusher.Error += (sender, error) =>
            {
                LoggerProvider.Log(LogLevel.ERROR, "Error on Pusher client: ", error);
                Error?.Invoke(this, error);
            };

            Bind();
            ResubscribeToChannels();

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
        public void SubscribeToProject(string project)
        {
            Subscribe(new ProjectChannel(Platform, project).Channel());
        }

        /// <inheritdoc/>
        public void UnsubscribeToProject(string project)
        {
            Unsubscribe(new ProjectChannel(Platform, project).Channel());
        }

        /// <inheritdoc/>
        public bool IsSubscribedToProject(string project)
        {
            lock (_subscribed)
                return _subscribed.Contains(new ProjectChannel(Platform, project).Channel());
        }

        /// <inheritdoc/>
        public void SubscribeToPlayer(string project, string player)
        {
            Subscribe(new PlayerChannel(Platform, project, player).Channel());
        }

        /// <inheritdoc/>
        public void UnsubscribeToPlayer(string project, string player)
        {
            Unsubscribe(new PlayerChannel(Platform, project, player).Channel());
        }

        /// <inheritdoc/>
        public bool IsSubscribedToPlayer(string project, string player)
        {
            lock (_subscribed)
                return _subscribed.Contains(new PlayerChannel(Platform, project, player).Channel());
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
            lock (_subscribed)
                return _subscribed.Contains(new AssetChannel(Platform, asset).Channel());
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
            lock (_subscribed)
                return _subscribed.Contains(new WalletChannel(Platform, wallet).Channel());
        }

        private void Subscribe(string channel)
        {
            if (_pusher == null)
                return;

            lock (_subscribed)
            {
                if (_subscribed.Contains(channel))
                    return;

                _pusher.SubscribeAsync(channel)
                       .ContinueWith(task =>
                       {
                           if (task.IsFaulted)
                               return;

                           lock (_subscribed)
                               _subscribed.Add(channel);
                       });
            }
        }

        private void ResubscribeToChannels()
        {
            List<string> channels;

            lock (_subscribed)
            {
                channels = new List<string>(_subscribed);
                _subscribed.Clear();
            }

            foreach (var channel in channels)
            {
                Subscribe(channel);
            }
        }

        private void Unsubscribe(string channel)
        {
            if (_pusher == null)
                return;

            lock (_subscribed)
            {
                if (!_subscribed.Contains(channel))
                    return;

                _pusher.UnsubscribeAsync(channel)
                       .ContinueWith(task =>
                       {
                           if (task.IsFaulted)
                               return;

                           lock (_subscribed)
                               _subscribed.Remove(channel);
                       });
            }
        }

        private void Bind()
        {
            // Binds all events for the client except for the UNKNOWN type
            EventTypeDef.Values()
                        .Where(d => d.Type != EventType.UNKNOWN)
                        .Do(d => _pusher!.Bind(d.Key, _listener.OnEvent));
        }
    }
}
using System;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Events
{
    /// <summary>
    /// Event service interface for subscribing to and registering for events from the Enjin Cloud.
    /// </summary>
    [PublicAPI]
    public interface IEventService
    {
        /// <summary>
        /// Starts this service. See <see cref="Start(Platform)"/> to start this service with new platform details.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts this service with the provided platform details. See <see cref="Start()"/> to start this service as
        /// is.
        /// </summary>
        /// <param name="platform">The platform.</param>
        void Start(Platform platform);

        /// <summary>
        /// Shuts down this service.
        /// </summary>
        void Shutdown();
        
        /// <summary>
        /// Checks if this service is connected to platform.
        /// </summary>
        /// <returns>True if connected, else false.</returns>
        bool IsConnected();

        /// <summary>
        /// Registers a event listener and provides the registration object used for it.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <returns>The registration.</returns>
        EventListenerRegistration RegisterListener(IEventListener listener);
        
        /// <summary>
        /// Registers a event listener with a delegate for event matching and provides the registration object used for
        /// it.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <param name="matcher">The event matcher.</param>
        /// <returns>The registration.</returns>
        EventListenerRegistration RegisterListenerWithMatcher(IEventListener listener, Func<EventType, bool> matcher);
        
        /// <summary>
        /// Adds a event listener with the event types to allow and provides the registration object to use.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <param name="events">The events to listen for.</param>
        /// <returns>The registration.</returns>
        EventListenerRegistration RegisterListenerIncludingTypes(IEventListener listener, params EventType[] events);
        
        /// <summary>
        /// Adds a event listener with the event types to ignore and provides the registration object used for it.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <param name="events">The events to not listen for..</param>
        /// <returns>The registration.</returns>
        EventListenerRegistration RegisterListenerExcludingTypes(IEventListener listener, params EventType[] events);

        /// <summary>
        /// Unregisters the event listener.
        /// </summary>
        /// <param name="listener">The listener.</param>
        void UnregisterListener(IEventListener listener);

        /// <summary>
        /// Opens a channel for the specified application, allowing listeners to receive events for that application.
        /// </summary>
        /// <param name="app">The app ID.</param>
        void SubscribeToApp(int app);
        
        /// <summary>
        /// Closes a channel for the specified application, preventing listeners from receiving events for that
        /// application.
        /// </summary>
        /// <param name="app">The app ID.</param>
        void UnsubscribeToApp(int app);

        /// <summary>
        /// Determines if the channel is open for the specified application.
        /// </summary>
        /// <param name="app">The app ID.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToApp(int app);
        
        /// <summary>
        /// Opens a channel for the specified player, allowing listeners to receive events for that player.
        /// </summary>
        /// <param name="app">The ID of the app the player is on.</param>
        /// <param name="player">The player ID.</param>
        void SubscribeToPlayer(int app, string player);
        
        /// <summary>
        /// Closes a channel for the specified player, preventing listeners from receiving events for that player.
        /// </summary>
        /// <param name="app">The ID of the app the player is on.</param>
        /// <param name="player">The player ID.</param>
        void UnsubscribeToPlayer(int app, string player);
        
        /// <summary>
        /// Determines if the channel is open for the specified player.
        /// </summary>
        /// <param name="app">The ID of the app the player is on.</param>
        /// <param name="player">The player ID.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToPlayer(int app, string player);
        
        /// <summary>
        /// Opens a channel for the specified asset, allowing listeners to receive events for that asset.
        /// </summary>
        /// <param name="asset">The asset ID.</param>
        void SubscribeToAsset(string asset);
        
        /// <summary>
        /// Closes a channel for the specified asset, preventing listeners from receiving events for that asset.
        /// </summary>
        /// <param name="asset">The asset ID.</param>
        void UnsubscribeToAsset(string asset);
        
        /// <summary>
        /// Determines if the channel is open for the specified asset.
        /// </summary>
        /// <param name="asset">The asset ID.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToAsset(string asset);
        
        /// <summary>
        /// Opens a channel for the specified wallet address, allowing listeners to receive events for that wallet
        /// address.
        /// </summary>
        /// <param name="wallet">The address.</param>
        void SubscribeToWallet(string wallet);
        
        /// <summary>
        /// Closes a channel for the specified wallet address, preventing listeners from receiving events for that
        /// wallet address.
        /// </summary>
        /// <param name="wallet">The address.</param>
        void UnsubscribeToWallet(string wallet);
        
        /// <summary>
        /// Determines if the channel is open for the specified wallet address.
        /// </summary>
        /// <param name="wallet">The address.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToWallet(string wallet);
    }
}
using System;
using System.Threading.Tasks;
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
        /// Event handler invoked when this service is connected to its server.
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Event handler invoked when this service is disconnected from its server.
        /// </summary>
        public event EventHandler Disconnected;

        /// <summary>
        /// Event handler invoked when this service encounters an error.
        /// </summary>
        public event EventHandler<Exception> Error;
        
        /// <summary>
        /// Starts this service. See <see cref="Start(Platform)"/> to start this service with new platform details.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        Task Start();

        /// <summary>
        /// Starts this service with the provided platform details. See <see cref="Start()"/> to start this service as
        /// is.
        /// </summary>
        /// <param name="platform">The platform.</param>
        /// <returns>The task for this operation.</returns>
        Task Start(Platform platform);

        /// <summary>
        /// Shuts down this service.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        Task Shutdown();
        
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
        /// Opens a channel for the specified project, allowing listeners to receive events for that project.
        /// </summary>
        /// <param name="project">The project ID.</param>
        /// <returns>The task for this operation.</returns>
        Task SubscribeToProject(int project);
        
        /// <summary>
        /// Closes a channel for the specified project, preventing listeners from receiving events for that project.
        /// </summary>
        /// <param name="project">The project ID.</param>
        /// <returns>The task for this operation.</returns>
        Task UnsubscribeToProject(int project);

        /// <summary>
        /// Determines if the channel is open for the specified project.
        /// </summary>
        /// <param name="project">The project ID.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToProject(int project);
        
        /// <summary>
        /// Opens a channel for the specified player, allowing listeners to receive events for that player.
        /// </summary>
        /// <param name="project">The ID of the project the player is on.</param>
        /// <param name="player">The player ID.</param>
        /// <returns>The task for this operation.</returns>
        Task SubscribeToPlayer(int project, string player);
        
        /// <summary>
        /// Closes a channel for the specified player, preventing listeners from receiving events for that player.
        /// </summary>
        /// <param name="project">The ID of the project the player is on.</param>
        /// <param name="player">The player ID.</param>
        /// <returns>The task for this operation.</returns>
        Task UnsubscribeToPlayer(int project, string player);
        
        /// <summary>
        /// Determines if the channel is open for the specified player.
        /// </summary>
        /// <param name="project">The ID of the project the player is on.</param>
        /// <param name="player">The player ID.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToPlayer(int project, string player);
        
        /// <summary>
        /// Opens a channel for the specified asset, allowing listeners to receive events for that asset.
        /// </summary>
        /// <param name="asset">The asset ID.</param>
        /// <returns>The task for this operation.</returns>
        Task SubscribeToAsset(string asset);
        
        /// <summary>
        /// Closes a channel for the specified asset, preventing listeners from receiving events for that asset.
        /// </summary>
        /// <param name="asset">The asset ID.</param>
        /// <returns>The task for this operation.</returns>
        Task UnsubscribeToAsset(string asset);
        
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
        /// <returns>The task for this operation.</returns>
        Task SubscribeToWallet(string wallet);
        
        /// <summary>
        /// Closes a channel for the specified wallet address, preventing listeners from receiving events for that
        /// wallet address.
        /// </summary>
        /// <param name="wallet">The address.</param>
        /// <returns>The task for this operation.</returns>
        Task UnsubscribeToWallet(string wallet);
        
        /// <summary>
        /// Determines if the channel is open for the specified wallet address.
        /// </summary>
        /// <param name="wallet">The address.</param>
        /// <returns>True if open, else false.</returns>
        bool IsSubscribedToWallet(string wallet);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public sealed class EventType : IComparable
    {
        public static readonly EventType APP_CREATED = Create("APP_CREATED", "EnjinCloud\\Events\\AppCreated", "app");
        public static readonly EventType APP_DELETED = Create("APP_DELETED", "EnjinCloud\\Events\\AppDeleted", "app");
        public static readonly EventType APP_LINKED = Create("APP_LINKED", "EnjinCloud\\Events\\AppLinked", "app", "wallet");
        public static readonly EventType APP_LOCKED = Create("APP_LOCKED", "EnjinCloud\\Events\\AppLocked", "app");
        public static readonly EventType APP_UNLINKED = Create("APP_UNLINKED", "EnjinCloud\\Events\\AppUnlinked", "app", "wallet");
        public static readonly EventType APP_UNLOCKED = Create("APP_UNLOCKED", "EnjinCloud\\Events\\AppUnlocked", "app");
        public static readonly EventType APP_UPDATED = Create("APP_UPDATED", "EnjinCloud\\Events\\AppUpdated", "app");
        public static readonly EventType BLOCKCHAIN_LOG_PROCESSED = Create("BLOCKCHAIN_LOG_PROCESSED", "EnjinCloud\\Events\\BlockchainLogProcessed", "app", "token", "wallet");
        public static readonly EventType MESSAGE_PROCESSED = Create("MESSAGE_PROCESSED", "EnjinCloud\\Events\\MessageProcessed", "app", "token", "wallet");
        public static readonly EventType PLAYER_CREATED = Create("PLAYER_CREATED", "EnjinCloud\\Events\\PlayerCreated", "app", "player");
        public static readonly EventType PLAYER_DELETED = Create("PLAYER_DELETED", "EnjinCloud\\Events\\PlayerDeleted", "app", "player");
        public static readonly EventType PLAYER_LINKED = Create("PLAYER_LINKED", "EnjinCloud\\Events\\PlayerLinked", "app", "player", "wallet");
        public static readonly EventType PLAYER_UNLINKED = Create("PLAYER_UNLINKED", "EnjinCloud\\Events\\PlayerUnlinked", "app", "player", "wallet");
        public static readonly EventType PLAYER_UPDATED = Create("PLAYER_UPDATED", "EnjinCloud\\Events\\PlayerUpdated", "app", "player");
        public static readonly EventType TOKEN_CREATED = Create("TOKEN_CREATED", "EnjinCloud\\Events\\TokenCreated", "app", "token", "wallet");
        public static readonly EventType TOKEN_MELTED = Create("TOKEN_MELTED", "EnjinCloud\\Events\\TokenMelted", "app", "token", "wallet");
        public static readonly EventType TOKEN_MINTED = Create("TOKEN_MINTED", "EnjinCloud\\Events\\TokenMinted", "app", "token", "wallet");
        public static readonly EventType TOKEN_TRANSFERRED = Create("TOKEN_TRANSFERRED", "EnjinCloud\\Events\\TokenTransferred", "app", "token", "wallet");
        public static readonly EventType TOKEN_UPDATED = Create("TOKEN_UPDATED", "EnjinCloud\\Events\\TokenUpdated", "app", "token", "wallet");
        public static readonly EventType TRADE_COMPLETED = Create("TRADE_COMPLETED", "EnjinCloud\\Events\\TradeCompleted", "app", "token", "wallet");
        public static readonly EventType TRADE_CREATED = Create("TRADE_CREATED", "EnjinCloud\\Events\\TradeCreated", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_BROADCAST = Create("TRANSACTION_BROADCAST", "EnjinCloud\\Events\\TransactionBroadcast", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_CANCELED = Create("TRANSACTION_CANCELED", "EnjinCloud\\Events\\TransactionCanceled", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_DROPPED = Create("TRANSACTION_DROPPED", "EnjinCloud\\Events\\TransactionDropped", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_EXECUTED = Create("TRANSACTION_EXECUTED", "EnjinCloud\\Events\\TransactionExecuted", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_FAILED = Create("TRANSACTION_FAILED", "EnjinCloud\\Events\\TransactionFailed", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_PENDING = Create("TRANSACTION_PENDING", "EnjinCloud\\Events\\TransactionPending", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_PROCESSING = Create("TRANSACTION_PROCESSING", "EnjinCloud\\Events\\TransactionProcessing", "app", "token", "wallet");
        public static readonly EventType TRANSACTION_UPDATED = Create("TRANSACTION_UPDATED", "EnjinCloud\\Events\\TransactionUpdated", "app", "token", "wallet");
        
        private static int _count;
        
        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public string[] ChannelTypes => (string[]) _channelTypes.Clone();
        private readonly string[] _channelTypes;
        
        internal EventType(int id, string name, string type, params string[] channelTypes)
        {
            Id = id;
            Name = name;
            Type = type;
            _channelTypes = channelTypes;
        }

        public int CompareTo(object other) => Id.CompareTo(((EventType) other).Id);

        public bool In(params EventType[] eventTypes) => eventTypes.Any(eventType => this == eventType);

        internal static EventType Create(string name, string type, params string[] channelTypes)
        {
            return new EventType(++_count, name, type, channelTypes);
        }

        public static IEnumerable<EventType> Values()
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo[] fields = typeof(EventType).GetFields(bindingFlags);
            return fields.Select(f => f.GetValue(null)).Cast<EventType>();
        }

        public static EventType ValueOf(string name)
        {
            EventType result = Values().FirstOrDefault(eventType => eventType.Name.Equals(name));
            if (result == null)
                throw new ArgumentException($"No event type with name: ${name} exists");
            
            return result;
        }

        public static List<EventType> FilterByChannelTypes(params string[] channels)
        {
            List<EventType> eventTypes = new List<EventType>();
            
            foreach (string channel in channels)
            {
                foreach (EventType eventType in Values())
                {
                    if (!eventType.ChannelTypes.Any(channelType => channelType.Equals(channel)))
                        continue;
                    
                    eventTypes.Add(eventType);
                    break;
                }
            }

            return eventTypes;
        }
        
        public static EventType? GetFromName(string name)
        {
            try
            {
                return ValueOf(name);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Enjin.SDK.Models;
using Enjin.SDK.Utils;
using JetBrains.Annotations;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Events
{
    [PublicAPI]
    internal sealed class EventTypeDef
    {
        private static readonly EventTypeDef UNKNOWN = Create(EventType.UNKNOWN);

        private static readonly EventTypeDef APP_CREATED =
            Create(EventType.APP_CREATED, "EnjinCloud\\Events\\AppCreated", "app");

        private static readonly EventTypeDef APP_DELETED =
            Create(EventType.APP_DELETED, "EnjinCloud\\Events\\AppDeleted", "app");

        private static readonly EventTypeDef APP_LINKED = Create(EventType.APP_LINKED, "EnjinCloud\\Events\\AppLinked",
            "app", "wallet");

        private static readonly EventTypeDef APP_LOCKED = Create(EventType.APP_LOCKED, "EnjinCloud\\Events\\AppLocked",
            "app");

        private static readonly EventTypeDef APP_UNLINKED =
            Create(EventType.APP_UNLINKED, "EnjinCloud\\Events\\AppUnlinked", "app", "wallet");

        private static readonly EventTypeDef APP_UNLOCKED =
            Create(EventType.APP_UNLOCKED, "EnjinCloud\\Events\\AppUnlocked", "app");

        private static readonly EventTypeDef APP_UPDATED =
            Create(EventType.APP_UPDATED, "EnjinCloud\\Events\\AppUpdated", "app");

        private static readonly EventTypeDef BLOCKCHAIN_LOG_PROCESSED = Create(EventType.BLOCKCHAIN_LOG_PROCESSED,
            "EnjinCloud\\Events\\BlockchainLogProcessed", "app", "asset", "wallet");

        private static readonly EventTypeDef MESSAGE_PROCESSED = Create(EventType.MESSAGE_PROCESSED,
            "EnjinCloud\\Events\\MessageProcessed", "app", "asset", "wallet");

        private static readonly EventTypeDef PLAYER_CREATED =
            Create(EventType.PLAYER_CREATED, "EnjinCloud\\Events\\PlayerCreated", "app", "player");

        private static readonly EventTypeDef PLAYER_DELETED =
            Create(EventType.PLAYER_DELETED, "EnjinCloud\\Events\\PlayerDeleted", "app", "player");

        private static readonly EventTypeDef PLAYER_LINKED = Create(EventType.PLAYER_LINKED,
            "EnjinCloud\\Events\\PlayerLinked", "app", "player", "wallet");

        private static readonly EventTypeDef PLAYER_UNLINKED = Create(EventType.PLAYER_UNLINKED,
            "EnjinCloud\\Events\\PlayerUnlinked", "app", "player", "wallet");

        private static readonly EventTypeDef PLAYER_UPDATED =
            Create(EventType.PLAYER_UPDATED, "EnjinCloud\\Events\\PlayerUpdated", "app", "player");

        private static readonly EventTypeDef ASSET_CREATED = Create(EventType.ASSET_CREATED,
            "EnjinCloud\\Events\\AssetCreated", "app", "asset", "wallet");

        private static readonly EventTypeDef ASSET_MELTED = Create(EventType.ASSET_MELTED,
            "EnjinCloud\\Events\\AssetMelted", "app", "asset", "wallet");

        private static readonly EventTypeDef ASSET_MINTED = Create(EventType.ASSET_MINTED,
            "EnjinCloud\\Events\\AssetMinted", "app", "asset", "wallet");

        private static readonly EventTypeDef ASSET_TRANSFERRED = Create(EventType.ASSET_TRANSFERRED,
            "EnjinCloud\\Events\\AssetTransferred", "app", "asset", "wallet");

        private static readonly EventTypeDef ASSET_UPDATED = Create(EventType.ASSET_UPDATED,
            "EnjinCloud\\Events\\AssetUpdated", "app", "asset", "wallet");

        private static readonly EventTypeDef TRADE_COMPLETED = Create(EventType.TRADE_COMPLETED,
            "EnjinCloud\\Events\\TradeCompleted", "app", "asset", "wallet");

        private static readonly EventTypeDef TRADE_CREATED = Create(EventType.TRADE_CREATED,
            "EnjinCloud\\Events\\TradeCreated", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_BROADCAST = Create(EventType.TRANSACTION_BROADCAST,
            "EnjinCloud\\Events\\TransactionBroadcast", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_CANCELED = Create(EventType.TRANSACTION_CANCELED,
            "EnjinCloud\\Events\\TransactionCanceled", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_DROPPED = Create(EventType.TRANSACTION_DROPPED,
            "EnjinCloud\\Events\\TransactionDropped", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_EXECUTED = Create(EventType.TRANSACTION_EXECUTED,
            "EnjinCloud\\Events\\TransactionExecuted", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_FAILED = Create(EventType.TRANSACTION_FAILED,
            "EnjinCloud\\Events\\TransactionFailed", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_PENDING = Create(EventType.TRANSACTION_PENDING,
            "EnjinCloud\\Events\\TransactionPending", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_PROCESSING = Create(EventType.TRANSACTION_PROCESSING,
            "EnjinCloud\\Events\\TransactionProcessing", "app", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_UPDATED = Create(EventType.TRANSACTION_UPDATED,
            "EnjinCloud\\Events\\TransactionUpdated", "app", "asset", "wallet");

        private static Dictionary<EventType, EventTypeDef> _map = new Dictionary<EventType, EventTypeDef>();

        public EventType Type { get; }
        public string Key { get; }
        public string[] Channels { get; }
        public string Name => Enum.GetName(typeof(EventType), Type);

        static EventTypeDef()
        {
            foreach (var field in typeof(EventTypeDef).GetFields(BindingFlags.NonPublic | BindingFlags.Static))
            {
                var v = field.GetValue(null) as EventTypeDef;
                if (v == null)
                    continue;
                _map.Add(v.Type, v);
            }
        }

        private EventTypeDef(EventType type, string key, params string[] channels)
        {
            Type = type;
            Key = key;
            Channels = channels;
        }

        private static EventTypeDef Create(EventType type) => Create(type, Enum.GetName(typeof(EventType), type));

        private static EventTypeDef Create(EventType type, string key, params string[] channels)
        {
            return new EventTypeDef(type, key, channels);
        }

        public bool In(params EventType[] types) => types.Any(type => Type == type);

        public static IEnumerable<EventTypeDef> Values() => _map.Values;

        public static List<EventTypeDef> FilterByChannelTypes(params string[] channels)
        {
            return (from channel in channels
                    from def in Values()
                    where def.Channels.Any(c => c.EqualsIgnoreCase(channel))
                    select def).ToList();
        }

        public static EventTypeDef GetFromName(string name)
        {
            return Values().FirstOrDefault(def => def.Name.EqualsIgnoreCase(name)) ?? UNKNOWN;
        }

        public static EventTypeDef GetFromKey(string key)
        {
            return Values().FirstOrDefault(def => def.Key.EqualsIgnoreCase(key)) ?? UNKNOWN;
        }
    }
}
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

        private static readonly EventTypeDef PROJECT_CREATED =
            Create(EventType.PROJECT_CREATED, "EnjinCloud\\Events\\ProjectCreated", "project");

        private static readonly EventTypeDef PROJECT_DELETED =
            Create(EventType.PROJECT_DELETED, "EnjinCloud\\Events\\ProjectDeleted", "project");

        private static readonly EventTypeDef PROJECT_LINKED = Create(EventType.PROJECT_LINKED,
                                                                     "EnjinCloud\\Events\\ProjectLinked",
                                                                     "project", "wallet");

        private static readonly EventTypeDef PROJECT_LOCKED = Create(EventType.PROJECT_LOCKED,
                                                                     "EnjinCloud\\Events\\ProjectLocked",
                                                                     "project");

        private static readonly EventTypeDef PROJECT_UNLINKED =
            Create(EventType.PROJECT_UNLINKED, "EnjinCloud\\Events\\ProjectUnlinked", "project", "wallet");

        private static readonly EventTypeDef PROJECT_UNLOCKED =
            Create(EventType.PROJECT_UNLOCKED, "EnjinCloud\\Events\\ProjectUnlocked", "project");

        private static readonly EventTypeDef PROJECT_UPDATED =
            Create(EventType.PROJECT_UPDATED, "EnjinCloud\\Events\\ProjectUpdated", "project");

        private static readonly EventTypeDef BLOCKCHAIN_LOG_PROCESSED = Create(EventType.BLOCKCHAIN_LOG_PROCESSED,
                                                                               "EnjinCloud\\Events\\BlockchainLogProcessed",
                                                                               "project", "asset", "wallet");

        private static readonly EventTypeDef MESSAGE_PROCESSED = Create(EventType.MESSAGE_PROCESSED,
                                                                        "EnjinCloud\\Events\\MessageProcessed",
                                                                        "project", "asset", "wallet");

        private static readonly EventTypeDef PLAYER_CREATED =
            Create(EventType.PLAYER_CREATED, "EnjinCloud\\Events\\PlayerCreated", "project", "player");

        private static readonly EventTypeDef PLAYER_DELETED =
            Create(EventType.PLAYER_DELETED, "EnjinCloud\\Events\\PlayerDeleted", "project", "player");

        private static readonly EventTypeDef PLAYER_LINKED = Create(EventType.PLAYER_LINKED,
                                                                    "EnjinCloud\\Events\\PlayerLinked", "project",
                                                                    "player", "wallet");

        private static readonly EventTypeDef PLAYER_UNLINKED = Create(EventType.PLAYER_UNLINKED,
                                                                      "EnjinCloud\\Events\\PlayerUnlinked", "project",
                                                                      "player", "wallet");

        private static readonly EventTypeDef PLAYER_UPDATED =
            Create(EventType.PLAYER_UPDATED, "EnjinCloud\\Events\\PlayerUpdated", "project", "player");

        private static readonly EventTypeDef ASSET_CREATED = Create(EventType.ASSET_CREATED,
                                                                    "EnjinCloud\\Events\\AssetCreated", "project",
                                                                    "asset", "wallet");

        private static readonly EventTypeDef ASSET_MELTED = Create(EventType.ASSET_MELTED,
                                                                   "EnjinCloud\\Events\\AssetMelted", "project",
                                                                   "asset", "wallet");

        private static readonly EventTypeDef ASSET_MINTED = Create(EventType.ASSET_MINTED,
                                                                   "EnjinCloud\\Events\\AssetMinted", "project",
                                                                   "asset", "wallet");

        private static readonly EventTypeDef ASSET_TRANSFERRED = Create(EventType.ASSET_TRANSFERRED,
                                                                        "EnjinCloud\\Events\\AssetTransferred",
                                                                        "project", "asset", "wallet");

        private static readonly EventTypeDef ASSET_UPDATED = Create(EventType.ASSET_UPDATED,
                                                                    "EnjinCloud\\Events\\AssetUpdated", "project",
                                                                    "asset", "wallet");

        private static readonly EventTypeDef TRADE_COMPLETED = Create(EventType.TRADE_ASSET_COMPLETED,
                                                                      "EnjinCloud\\Events\\TradeAssetCompleted", "project",
                                                                      "asset", "wallet");

        private static readonly EventTypeDef TRADE_CREATED = Create(EventType.TRADE_ASSET_CREATED,
                                                                    "EnjinCloud\\Events\\TradeAssetCreated", "project",
                                                                    "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_BROADCAST = Create(EventType.TRANSACTION_BROADCAST,
                                                                            "EnjinCloud\\Events\\TransactionBroadcast",
                                                                            "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_CANCELED = Create(EventType.TRANSACTION_CANCELED,
                                                                           "EnjinCloud\\Events\\TransactionCanceled",
                                                                           "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_DROPPED = Create(EventType.TRANSACTION_DROPPED,
                                                                          "EnjinCloud\\Events\\TransactionDropped",
                                                                          "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_EXECUTED = Create(EventType.TRANSACTION_EXECUTED,
                                                                           "EnjinCloud\\Events\\TransactionExecuted",
                                                                           "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_FAILED = Create(EventType.TRANSACTION_FAILED,
                                                                         "EnjinCloud\\Events\\TransactionFailed",
                                                                         "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_PENDING = Create(EventType.TRANSACTION_PENDING,
                                                                          "EnjinCloud\\Events\\TransactionPending",
                                                                          "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_PROCESSING = Create(EventType.TRANSACTION_PROCESSING,
                                                                             "EnjinCloud\\Events\\TransactionProcessing",
                                                                             "project", "asset", "wallet");

        private static readonly EventTypeDef TRANSACTION_UPDATED = Create(EventType.TRANSACTION_UPDATED,
                                                                          "EnjinCloud\\Events\\TransactionUpdated",
                                                                          "project", "asset", "wallet");

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
                    where def.Channels.Any(channel.Contains)
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
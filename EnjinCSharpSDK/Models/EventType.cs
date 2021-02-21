using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Enums defining the different types of notifications that may be received from the platform.
    /// </summary>
    [PublicAPI]
    public enum EventType
    {
        /// <summary>
        /// Value used by the SDK to indicate an unknown event type.
        /// </summary>
        UNKNOWN,
        APP_CREATED,
        APP_DELETED,
        APP_LINKED,
        APP_LOCKED,
        APP_UNLINKED,
        APP_UNLOCKED,
        APP_UPDATED,
        BLOCKCHAIN_LOG_PROCESSED,
        MESSAGE_PROCESSED,
        PLAYER_CREATED,
        PLAYER_DELETED,
        PLAYER_LINKED,
        PLAYER_UNLINKED,
        PLAYER_UPDATED,
        ASSET_CREATED,
        ASSET_MELTED,
        ASSET_MINTED,
        ASSET_TRANSFERRED,
        ASSET_UPDATED,
        TRADE_COMPLETED,
        TRADE_CREATED,
        TRANSACTION_BROADCAST,
        TRANSACTION_CANCELED,
        TRANSACTION_DROPPED,
        TRANSACTION_EXECUTED,
        TRANSACTION_FAILED,
        TRANSACTION_PENDING,
        TRANSACTION_PROCESSING,
        TRANSACTION_UPDATED,
    }
}
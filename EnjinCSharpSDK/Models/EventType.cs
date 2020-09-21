﻿using JetBrains.Annotations;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Enums defining the different types of notifications that may be received from the platform.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Events.EventTypeDef"/>
    [PublicAPI]
    public enum EventType
    {
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
        TOKEN_CREATED,
        TOKEN_MELTED,
        TOKEN_MINTED,
        TOKEN_TRANSFERRED,
        TOKEN_UPDATED,
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
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

using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Represents the transaction type when creating or updating a transaction.
    /// </summary>
    /// <seealso cref="Transaction"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum TransactionType
    {
        [EnumMember(Value = "ACCEPT_ASSIGNMENT")]
        ACCEPT_ASSIGNMENT,

        [EnumMember(Value = "ASSIGN")]
        ASSIGN,

        [EnumMember(Value = "APPROVE")]
        APPROVE,

        [EnumMember(Value = "CREATE")]
        CREATE,

        [EnumMember(Value = "MINT")]
        MINT,

        [EnumMember(Value = "SEND")]
        SEND,

        [EnumMember(Value = "SEND_ENJ")]
        SEND_ENJ,

        [EnumMember(Value = "ADVANCED_SEND")]
        ADVANCED_SEND,

        [EnumMember(Value = "CREATE_TRADE")]
        CREATE_TRADE,

        [EnumMember(Value = "COMPLETE_TRADE")]
        COMPLETE_TRADE,

        [EnumMember(Value = "CANCEL_TRADE")]
        CANCEL_TRADE,

        [EnumMember(Value = "MELT")]
        MELT,

        [EnumMember(Value = "UPDATE_NAME")]
        UPDATE_NAME,

        [EnumMember(Value = "SET_ITEM_URI")]
        SET_ITEM_URI,

        [EnumMember(Value = "SET_WHITELISTED")]
        SET_WHITELISTED,

        [EnumMember(Value = "SET_TRANSFERABLE")]
        SET_TRANSFERABLE,

        [EnumMember(Value = "SET_MELT_FEE")]
        SET_MELT_FEE,

        [EnumMember(Value = "DECREASE_MAX_MELT_FEE")]
        DECREASE_MAX_MELT_FEE,

        [EnumMember(Value = "SET_TRANSFER_FEE")]
        SET_TRANSFER_FEE,

        [EnumMember(Value = "DECREASE_MAX_TRANSFER_FEE")]
        DECREASE_MAX_TRANSFER_FEE,

        [EnumMember(Value = "RELEASE_RESERVE")]
        RELEASE_RESERVE,

        [EnumMember(Value = "ADD_LOG")]
        ADD_LOG,

        [EnumMember(Value = "SET_APPROVAL_FOR_ALL")]
        SET_APPROVAL_FOR_ALL,

        [EnumMember(Value = "MANAGER_UPDATE")]
        MANAGER_UPDATE,

        [EnumMember(Value = "SET_DECIMALS")]
        SET_DECIMALS,

        [EnumMember(Value = "SET_SYMBOL")]
        SET_SYMBOL,

        [EnumMember(Value = "MESSAGE")]
        MESSAGE,
    }
}
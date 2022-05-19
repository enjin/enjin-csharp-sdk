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
    /// The fields of the <see cref="Transaction"/> type.
    /// </summary>
    /// <seealso cref="TransactionSortInput"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum TransactionField
    {
        [EnumMember(Value = "id")]
        ID,

        [EnumMember(Value = "state")]
        STATE,

        [EnumMember(Value = "title")]
        TITLE,

        [EnumMember(Value = "createdAt")]
        CREATED_AT,

        [EnumMember(Value = "updatedAt")]
        UPDATED_AT,
    }
}
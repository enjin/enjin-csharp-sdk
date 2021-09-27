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
    /// The operator type for filters.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum Operator
    {
        [EnumMember(Value = "GREATER_THAN")]
        GREATER_THAN,

        [EnumMember(Value = "GREATER_THAN_OR_EQUAL")]
        GREATER_THAN_OR_EQUAL,

        [EnumMember(Value = "LESS_THAN")]
        LESS_THAN,

        [EnumMember(Value = "LESS_THAN_OR_EQUAL")]
        LESS_THAN_OR_EQUAL,
    }
}
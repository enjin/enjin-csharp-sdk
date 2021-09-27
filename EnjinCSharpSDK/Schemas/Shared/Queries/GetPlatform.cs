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

using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting the platform details.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Platform"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetPlatform : GraphqlRequest<GetPlatform>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetPlatform() : base("enjin.sdk.shared.GetPlatform")
        {
        }
        
        /// <summary>
        /// Sets the request to include the contracts with the platform.
        /// </summary>
        /// <returns>This request for chaining.</returns>
        public GetPlatform WithContracts()
        {
            return SetVariable("withContracts", true);
        }

        /// <summary>
        /// Sets the request to include the notification drivers with the platform.
        /// </summary>
        /// <returns>This request for chaining.</returns>
        public GetPlatform WithNotificationDrivers()
        {
            return SetVariable("withNotificationDrivers", true);
        }
    }
}
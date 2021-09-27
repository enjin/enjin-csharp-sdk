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

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to obtain the access token for the project.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.AccessToken"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class AuthProject : GraphqlRequest<AuthProject>
    {
        /// <summary>
        /// Sole construction.
        /// </summary>
        public AuthProject() : base("enjin.sdk.project.AuthProject")
        {
        }

        /// <summary>
        /// Sets the project UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>This request for chaining.</returns>
        public AuthProject Uuid(string? uuid)
        {
            return SetVariable("uuid", uuid);
        }

        /// <summary>
        /// Sets the project secret.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <returns>This request for chaining.</returns>
        public AuthProject Secret(string? secret)
        {
            return SetVariable("secret", secret);
        }
    }
}
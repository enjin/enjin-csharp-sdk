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
    /// Request for approving the crypto items contracts to spend ENJ.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class ApproveEnj : GraphqlRequest<ApproveEnj>, IProjectTransactionRequestArguments<ApproveEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ApproveEnj() : base("enjin.sdk.project.ApproveEnj")
        {
        }

        /// <summary>
        /// Sets the amount of ENJ to approve.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The value is in Wei as 10^18 (e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public ApproveEnj Value(string? value)
        {
            return SetVariable("value", value);
        }
    }
}
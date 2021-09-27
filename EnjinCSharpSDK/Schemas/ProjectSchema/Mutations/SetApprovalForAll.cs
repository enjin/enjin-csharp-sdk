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
    /// Request for allowing an operator complete control of all assets owned by the caller.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetApprovalForAll : GraphqlRequest<SetApprovalForAll>, IProjectTransactionRequestArguments<SetApprovalForAll>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetApprovalForAll() : base("enjin.sdk.project.SetApprovalForAll")
        {
        }

        /// <summary>
        /// Sets the wallet address of the operator.
        /// </summary>
        /// <param name="operatorAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SetApprovalForAll OperatorAddress(string? operatorAddress)
        {
            return SetVariable("operatorAddress", operatorAddress);
        }

        /// <summary>
        /// Sets the approval state.
        /// </summary>
        /// <param name="approved">The approval.</param>
        /// <returns>This request for chaining.</returns>
        public SetApprovalForAll Approved(bool? approved)
        {
            return SetVariable("approved", approved);
        }
    }
}
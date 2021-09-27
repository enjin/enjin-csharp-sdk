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

using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Interface used to set common arguments used in transaction requests in the project schema.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Request"/>
    [PublicAPI]
    public interface IProjectTransactionRequestArguments<out T> : ITransactionFragmentArguments<T>
    {
    }
    
    /// <summary>
    /// Class with extension methods for <see cref="IProjectTransactionRequestArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class ProjectTransactionRequestArguments
    {
        /// <summary>
        /// Sets the Ethereum address of the sender.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="ethAddress">The address.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T EthAddress<T>(this T instance, string? ethAddress) where T : IProjectTransactionRequestArguments<T>
        {
            return instance.SetVariable("ethAddress", ethAddress);
        }
    }
}
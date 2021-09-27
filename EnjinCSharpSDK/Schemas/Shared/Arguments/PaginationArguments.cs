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
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to set pagination options for a pagination returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    [PublicAPI]
    public interface IPaginationArguments<out T> : IVariableHolder<T>
    {
    }

    /// <summary>
    /// Class with extension methods for <see cref="IPaginationArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class PaginationArguments
    {
        /// <summary>
        /// Sets the pagination options.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="pagination">The options.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T Paginate<T>(this T instance, PaginationOptions? pagination) where T : IPaginationArguments<T>
        {
            return instance.SetVariable("pagination", pagination);
        }

        /// <summary>
        /// Creates pagination options that are then set.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="page">The page to start on.</param>
        /// <param name="limit">The number of items per page.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T Paginate<T>(this T instance, int? page, int? limit) where T : IPaginationArguments<T>
        {
            return Paginate(instance, new PaginationOptions
            {
                Page = page,
                Limit = limit
            });
        }
    }
}
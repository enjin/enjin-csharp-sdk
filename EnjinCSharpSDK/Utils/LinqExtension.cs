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

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestSuite")]
namespace Enjin.SDK.Utils
{
    /// <summary>
    /// Class with extension methods for LINQ expressions.
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// Performs an action on each element.
        /// </summary>
        /// <param name="elements">An <see cref="IEnumerable{T}"/> to perform an action in.</param>
        /// <param name="action">An action to perform.</param>
        /// <typeparam name="T">The type of the elements of the source.</typeparam>
        public static void Do<T>(this IEnumerable<T> elements, Action<T> action)
        {
            foreach (var e in elements)
            {
                action(e);
            }
        }
    }
}
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

namespace Enjin.SDK.Utils
{
    /// <summary>
    /// Class with extension methods for string objects.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Determines if this string and a specified string are equal while ignore the case their characters.
        /// </summary>
        /// <param name="self">A <see cref="String"/> that is the basis of this operation.</param>
        /// <param name="other">The <see cref="String"/> being compared to.</param>
        /// <returns>True if the strings are equal without case sensitivity, else false.</returns>
        /// <remarks>
        /// This method provides easier use and access to the <see cref="String.Equals(String, StringComparison)"/>
        /// using the <see cref="StringComparison.OrdinalIgnoreCase"/> type.
        /// </remarks>
        public static bool EqualsIgnoreCase(this string self, string other)
        {
            return self!.Equals(other, StringComparison.OrdinalIgnoreCase);
        }
    }
}
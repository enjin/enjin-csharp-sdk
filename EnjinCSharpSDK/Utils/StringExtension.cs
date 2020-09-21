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
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
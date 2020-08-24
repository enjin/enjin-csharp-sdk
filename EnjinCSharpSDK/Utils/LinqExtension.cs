using System;
using System.Collections.Generic;

namespace Enjin.SDK.Utils
{
    public static class LinqExtension
    {
        public static void Do<T>(this IEnumerable<T> elements, Action<T> action)
        {
            foreach (var e in elements)
            {
                action(e);
            }
        }
    }
}
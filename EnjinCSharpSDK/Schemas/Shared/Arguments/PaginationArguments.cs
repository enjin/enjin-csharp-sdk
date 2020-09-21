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
        public static T Paginate<T>(this T instance, PaginationOptions pagination) where T : IPaginationArguments<T>
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
        public static T Paginate<T>(this T instance, int? page, int? limit = 10) where T : IPaginationArguments<T>
        {
            return Paginate(instance, new PaginationOptions()
            {
                Page = page,
                Limit = limit
            });
        }
    }
}
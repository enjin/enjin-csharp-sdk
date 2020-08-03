using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface IPaginationArguments<out T> : IVariableHolder<T>
    {
    }

    [PublicAPI]
    public static class PaginationArguments
    {
        public static T Paginate<T>(this T instance, PaginationOptions pagination) where T : IVariableHolder<T>
        {
            return instance.SetVariable("pagination", pagination);
        }

        public static T Paginate<T>(this T instance, int page, int limit = 10) where T : IVariableHolder<T>
        {
            return Paginate(instance, new PaginationOptions()
            {
                Page = page,
                Limit = limit
            });
        }
    }
}
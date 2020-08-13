using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface IBalanceFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    [PublicAPI]
    public static class BalanceFragmentArguments
    {
        public static T BalIdFormat<T>(this T instance, TokenIdFormat balIdFormat) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("balIdFormat", balIdFormat);
        }
        
        public static T BalIndexFormat<T>(this T instance, TokenIndexFormat balIndexFormat) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("balIndexFormat", balIndexFormat);
        }
        
        public static T WithBalProjectId<T>(this T instance) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("withBalAppId", true);
        }
        
        public static T WithBalWalletAddress<T>(this T instance) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("withBalWalletAddress", true);
        }
    }
}
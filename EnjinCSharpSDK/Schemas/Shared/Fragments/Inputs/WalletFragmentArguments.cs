using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface IWalletFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    [PublicAPI]
    public static class WalletFragmentArguments
    {
        public static T WithTokensCreated<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withTokensCreated", true);
        }
    }
}
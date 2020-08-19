using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface IPlayerFragmentArguments<out T> : IVariableHolder<T>
    {
    }

    [PublicAPI]
    public static class PlayerFragmentArguments
    {
        public static T WithLinkingCode<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withLinkingCode", true);
        }
        
        public static T WithLinkingCodeQr<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withLinkingCodeQr", true);
        }
        
        public static T WithWallet<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withPlayerWallet", true);
        }
        
        public static T QrSize<T>(this T instance, int? size) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("linkingCodeQrSize", size);
        }
    }
}
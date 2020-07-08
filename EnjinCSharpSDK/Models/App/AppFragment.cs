using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public interface IAppFragment<out T> : IVariableHolder<T>
    {
    }

    [PublicAPI]
    public static class AppFragment
    {
        public static T WithSecret<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withSecret", true);
        }

        public static T WithLinkingCode<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withLinkingCode", true);
        }
        
        public static T WithLinkingCodeQr<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withLinkingCodeQr", true);
        }

        public static T LinkingCodeQrSize<T>(this T instance, int size) where T : IVariableHolder<T>
        {
            return instance.SetVariable("linkingCodeQrSize", size);
        }
        
        public static T WithCurrentUserIdentity<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withCurrentUserIdentity", true);
        }
        
        public static T WithOwner<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withOwner", true);
        }
        
        public static T WithTokenCount<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withTokenCount", true);
        }
        
        public static T WithAppTimestamps<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("WithAppTimestamps", true);
        }
    }
}
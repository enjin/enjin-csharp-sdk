using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface ITokenFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    [PublicAPI]
    public static class TokenFragmentArguments
    {
        public static T TokenIdFormat<T>(this T instance, TokenIdFormat tokenIdFormat) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("tokenIdFormat", tokenIdFormat);
        }
        
        public static T WithTokenBlocks<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTokenBlocks", true);
        }
        
        public static T WithCreator<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withCreator", true);
        }
        
        public static T WithMeltDetails<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withMeltDetails", true);
        }
        
        public static T WithMetadataUri<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withMetadataURI", true);
        }
        
        public static T WithSupplyDetails<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withSupplyDetails", true);
        }
        
        public static T WithTransferSettings<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTransferSettings", true);
        }
        
        public static T WithTokenVariantMode<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTokenVariantMode", true);
        }
        
        public static T WithTokenVariants<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTokenVariants", true);
        }
    }
}
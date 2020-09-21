using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from tokens returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Token"/>
    [PublicAPI]
    public interface ITokenFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    /// <summary>
    /// Class with extension methods for <see cref="ITokenFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class TokenFragmentArguments
    {
        /// <summary>
        /// Sets the desired token (item) ID format.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="tokenIdFormat">The format.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T TokenIdFormat<T>(this T instance, TokenIdFormat? tokenIdFormat) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("tokenIdFormat", tokenIdFormat);
        }
        
        /// <summary>
        /// Sets the request to include the block data with the token (item).
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithTokenBlocks<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTokenBlocks", true);
        }
        
        /// <summary>
        /// Sets the request to include the creator with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithCreator<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withCreator", true);
        }
        
        /// <summary>
        /// Sets the request to include the melt details with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithMeltDetails<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withMeltDetails", true);
        }
        
        /// <summary>
        /// Sets the request to include the metadata URI with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithMetadataUri<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withMetadataURI", true);
        }
        
        /// <summary>
        /// Sets the request to include the supply details with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithSupplyDetails<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withSupplyDetails", true);
        }
        
        /// <summary>
        /// Sets the request to include the transfer settings with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithTransferSettings<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTransferSettings", true);
        }
        
        /// <summary>
        /// Sets the request to include the variant mode with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithTokenVariantMode<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTokenVariantMode", true);
        }
        
        /// <summary>
        /// Sets the request to include the variants with the item.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithTokenVariants<T>(this T instance) where T : ITokenFragmentArguments<T>
        {
            return instance.SetVariable("withTokenVariants", true);
        }
    }
}
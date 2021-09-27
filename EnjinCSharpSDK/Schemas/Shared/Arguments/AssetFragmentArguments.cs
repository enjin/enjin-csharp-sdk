/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from assets returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Asset"/>
    [PublicAPI]
    public interface IAssetFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    /// <summary>
    /// Class with extension methods for <see cref="IAssetFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class AssetFragmentArguments
    {
        /// <summary>
        /// Sets the desired asset ID format.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="assetIdFormat">The format.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T AssetIdFormat<T>(this T instance, AssetIdFormat? assetIdFormat) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("assetIdFormat", assetIdFormat);
        }

        /// <summary>
        /// Sets the request to include state data about the asset.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="WithCreator{T}"/>
        /// <seealso cref="WithAssetBlocks{T}"/>
        /// <seealso cref="WithSupplyDetails{T}"/>
        public static T WithStateData<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withStateData", true);
        }

        /// <summary>
        /// Sets the request to include configuration data about the asset.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="WithMeltDetails{T}"/>
        /// <seealso cref="WithMetadataUri{T}"/>
        /// <seealso cref="WithTransferSettings{T}"/>
        public static T WithConfigData<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withConfigData", true);
        }
        
        /// <summary>
        /// Sets the request to include the block data with the asset when used with
        /// <see cref="WithStateData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithAssetBlocks<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withAssetBlocks", true);
        }
        
        /// <summary>
        /// Sets the request to include the creator with the asset when used with
        /// <see cref="WithStateData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithCreator<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withCreator", true);
        }
        
        /// <summary>
        /// Sets the request to include the melt details with the asset when used with
        /// <see cref="WithConfigData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithMeltDetails<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withMeltDetails", true);
        }
        
        /// <summary>
        /// Sets the request to include the metadata URI with the asset when used with
        /// <see cref="WithConfigData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithMetadataUri<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withMetadataURI", true);
        }
        
        /// <summary>
        /// Sets the request to include the supply details with the asset when used with
        /// <see cref="WithStateData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithSupplyDetails<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withSupplyDetails", true);
        }
        
        /// <summary>
        /// Sets the request to include the transfer settings with the asset when used with
        /// <see cref="WithConfigData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithTransferSettings<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withTransferSettings", true);
        }
        
        /// <summary>
        /// Sets the request to include the variant mode with the asset.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithAssetVariantMode<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withAssetVariantMode", true);
        }
        
        /// <summary>
        /// Sets the request to include the variants with the asset.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="WithVariantMetadata{T}"/>
        public static T WithAssetVariants<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withAssetVariants", true);
        }

        /// <summary>
        /// Sets the request to include the metadata for the variant(s) with the asset when used with
        /// <see cref="WithAssetVariants{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithVariantMetadata<T>(this T instance) where T : IAssetFragmentArguments<T>
        {
            return instance.SetVariable("withVariantMetadata", true);
        }
    }
}
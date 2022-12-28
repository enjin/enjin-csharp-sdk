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

using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from players returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Player"/>
    [PublicAPI]
    public interface IPlayerFragmentArguments<out T> : IWalletFragmentArguments<T>
    {
    }

    /// <summary>
    /// Class with extension methods for <see cref="IPlayerFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class PlayerFragmentArguments
    {
        /// <summary>
        /// Sets the request to include linking information with the player.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="QrSize{T}"/>
        public static T WithLinkingInfo<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withLinkingInfo", true);
        }

        /// <summary>
        /// Sets the request to include the wallet with the player.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithWallet<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withPlayerWallet", true);
        }

        /// <summary>
        /// Sets the desired size of the QR image in pixels. Must be used with <see cref="WithLinkingInfo{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="size">The size in pixels.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T QrSize<T>(this T instance, int? size) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("linkingCodeQrSize", size);
        }
    }
}
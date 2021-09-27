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
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from wallets returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Wallet"/>
    [PublicAPI]
    public interface IWalletFragmentArguments<out T> : IAssetFragmentArguments<T>
    {
    }
    
    /// <summary>
    /// Class with extension methods for <see cref="IWalletFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class WalletFragmentArguments
    {
        /// <summary>
        /// Sets the request to include the assets the wallet created with the wallet.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithAssetsCreated<T>(this T instance) where T : IWalletFragmentArguments<T>
        {
            return instance.SetVariable("withAssetsCreated", true);
        }
    }
}
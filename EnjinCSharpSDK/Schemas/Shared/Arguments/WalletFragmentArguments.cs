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

using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from wallets returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Wallet"/>
    [PublicAPI]
    public interface IWalletFragmentArguments<out T> : IAssetFragmentArguments<T>,
                                                       IBalanceFragmentArguments<T>,
                                                       ITransactionFragmentArguments<T>
    {
    }

    /// <summary>
    /// Class with extension methods for <see cref="IWalletFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class WalletFragmentArguments
    {
        /// <summary>
        /// Sets the balance filter when used with <see cref="WithWalletBalances{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="filter">The filter.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WalletBalanceFilter<T>(this T instance, BalanceFilter? filter)
            where T : IWalletFragmentArguments<T>
        {
            return instance.SetVariable("walletBalanceFilter", filter);
        }

        /// <summary>
        /// Sets the request to include the created assets of the wallet.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="Asset"/>
        public static T WithAssetsCreated<T>(this T instance) where T : IWalletFragmentArguments<T>
        {
            return instance.SetVariable("withAssetsCreated", true);
        }

        /// <summary>
        /// Sets the request to include the asset balances of the wallet.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="WalletBalanceFilter{T}"/>
        /// <seealso cref="Balance"/>
        public static T WithWalletBalances<T>(this T instance) where T : IWalletFragmentArguments<T>
        {
            return instance.SetVariable("withWalletBalances", true);
        }

        /// <summary>
        /// Sets the request to include the transactions the wallet has signed.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="Transaction"/>
        public static T WithWalletTransactions<T>(this T instance) where T : IWalletFragmentArguments<T>
        {
            return instance.SetVariable("withWalletTransactions", true);
        }
    }
}
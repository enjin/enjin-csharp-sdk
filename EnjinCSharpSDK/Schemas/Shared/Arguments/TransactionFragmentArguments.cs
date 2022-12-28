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
    /// Fragment interface used to request certain information from transactions returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Transaction"/>
    [PublicAPI]
    public interface ITransactionFragmentArguments<out T> : IVariableHolder<T>
    {
    }

    /// <summary>
    /// Class with extension methods for <see cref="ITransactionFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class TransactionFragmentArguments
    {
        /// <summary>
        /// Sets the request to include the blockchain data of the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="BlockchainData"/>
        /// <seealso cref="WithEncodedData{T}"/>
        /// <seealso cref="WithSignedTxs{T}"/>
        /// <seealso cref="WithReceipt{T}"/>
        /// <seealso cref="WithError{T}"/>
        /// <seealso cref="WithNonce{T}"/>
        public static T WithBlockchainData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withBlockchainData", true);
        }

        /// <summary>
        /// Sets the request to include the metadata of the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithMeta<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withMeta", true);
        }

        /// <summary>
        /// Sets the request to include the encoded data of the transaction when used with
        /// <see cref="WithBlockchainData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithEncodedData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withEncodedData", true);
        }

        /// <summary>
        /// Sets the request to include the asset data of the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="TransactionAssetIdFormat{T}"/>
        public static T WithAssetData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withAssetData", true);
        }

        /// <summary>
        /// Sets the request to include the signed transactions of the transaction when used with
        /// <see cref="WithBlockchainData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithSignedTxs<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withSignedTxs", true);
        }

        /// <summary>
        /// Sets the request to include the error of the transaction when used with
        /// <see cref="WithBlockchainData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithError<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withError", true);
        }

        /// <summary>
        /// Sets the request to include the nonce of the transaction when used with
        /// <see cref="WithBlockchainData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithNonce<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withNonce", true);
        }

        /// <summary>
        /// Sets the request to include the state of the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="TransactionState"/>
        public static T WithState<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withState", true);
        }

        /// <summary>
        /// Sets the request to include the transaction receipt of the transaction when used with
        /// <see cref="WithBlockchainData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="TransactionReceipt"/>
        /// <seealso cref="WithReceiptLogs{T}"/>
        public static T WithReceipt<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withReceipt", true);
        }

        /// <summary>
        /// Sets the request to include the logs of the transaction receipt when used with <see cref="WithReceipt{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="TransactionLog"/>
        /// <seealso cref="TransactionReceipt"/>
        /// <seealso cref="WithLogEvent{T}"/>
        public static T WithReceiptLogs<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withReceiptLogs", true);
        }

        /// <summary>
        /// Sets the request to include the event data of the receipt logs when used with
        /// <see cref="WithReceiptLogs{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="TransactionEvent"/>
        /// <seealso cref="TransactionLog"/>
        public static T WithLogEvent<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withLogEvent", true);
        }

        /// <summary>
        /// Sets the request to include the project with its UUID that the transaction belongs to.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <see cref="Project"/>
        public static T WithTransactionProjectUuid<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withTransactionProjectUuid", true);
        }

        /// <summary>
        /// Sets the request to include the wallet with its Ethereum address that belongs to the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <seealso cref="Wallet"/>
        public static T WithTransactionWalletAddress<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withTransactionWalletAddress", true);
        }

        /// <summary>
        /// Sets the desired asset ID format when used with <see cref="WithAssetData{T}"/>.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="assetIdFormat">The format.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T TransactionAssetIdFormat<T>(this T instance, AssetIdFormat? assetIdFormat)
            where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("transactionAssetIdFormat", assetIdFormat);
        }
    }
}
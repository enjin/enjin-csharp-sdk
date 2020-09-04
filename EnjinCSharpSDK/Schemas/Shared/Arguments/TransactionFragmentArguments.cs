using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from transactions returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Request"/>
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
        /// Sets the request to include the metadata with transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithMeta<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withMeta", true);
        }
        
        /// <summary>
        /// Sets the request to include the encoded data with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithEncodedData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withEncodedData", true);
        }
        
        /// <summary>
        /// Sets the request to include the token (item) data with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithTokenData<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withTokenData", true);
        }
        
        /// <summary>
        /// Sets the request to include the signed transactions with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithSignedTxs<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withSignedTxs", true);
        }
        
        /// <summary>
        /// Sets the request to include the error with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithError<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withError", true);
        }
        
        /// <summary>
        /// Sets the request to include the nonce with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithNonce<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withNonce", true);
        }
        
        /// <summary>
        /// Sets the request to include the state with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithState<T>(this T instance) where T : ITransactionFragmentArguments<T>
        {
            return instance.SetVariable("withState", true);
        }
        
        /// <summary>
        /// Sets the request to include the receipt with the transaction.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithReceipt<T>(this T instance) where T : IVariableHolder<T>
        {
            return instance.SetVariable("withReceipt", true);
        }
    }
}
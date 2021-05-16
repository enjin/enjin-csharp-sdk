using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Interface used to set common arguments used in transaction requests.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Request"/>
    [PublicAPI]
    public interface ITransactionRequestArguments<out T> : ITransactionFragmentArguments<T>
    {
    }
    
    /// <summary>
    /// Class with extension methods for <see cref="ITransactionRequestArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class TransactionRequestArguments
    {
        /// <summary>
        /// Sets the Ethereum address of the sender.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="ethAddress">The address.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T EthAddress<T>(this T instance, string? ethAddress) where T : ITransactionRequestArguments<T>
        {
            return instance.SetVariable("ethAddress", ethAddress);
        }

        /// <summary>
        /// Sets whether the request will send the transaction to the blockchain.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="send">The send state.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        /// <remarks>
        /// Setting this to false allows for arguments to be tried out without hitting the blockchain.
        /// </remarks>
        public static T Send<T>(this T instance, bool? send) where T : ITransactionRequestArguments<T>
        {
            return instance.SetVariable("send", send);
        }
    }
}
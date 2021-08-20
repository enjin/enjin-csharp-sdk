using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from balances returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Balance"/>
    [PublicAPI]
    public interface IBalanceFragmentArguments<out T> : IVariableHolder<T>
    {
    }
    
    /// <summary>
    /// Class with extension methods for <see cref="IBalanceFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class BalanceFragmentArguments
    {
        /// <summary>
        /// Sets the desired asset ID format.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="balIdFormat">The format.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T BalIdFormat<T>(this T instance, AssetIdFormat? balIdFormat) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("balIdFormat", balIdFormat);
        }
        
        /// <summary>
        /// Sets the desired index format for non-fungible assets.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <param name="balIndexFormat">The format.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T BalIndexFormat<T>(this T instance, AssetIndexFormat? balIndexFormat) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("balIndexFormat", balIndexFormat);
        }
        
        /// <summary>
        /// Sets the request to include the project UUID with the balance.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithBalProjectUuid<T>(this T instance) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("withBalProjectUuid", true);
        }
        
        /// <summary>
        /// Sets the request to include the wallet address with the balance.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithBalWalletAddress<T>(this T instance) where T : IBalanceFragmentArguments<T>
        {
            return instance.SetVariable("withBalWalletAddress", true);
        }
    }
}
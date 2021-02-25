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
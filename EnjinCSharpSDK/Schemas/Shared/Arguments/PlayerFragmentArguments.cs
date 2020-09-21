using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Fragment interface used to request certain information from players returned by the platform.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    /// <seealso cref="Enjin.SDK.Models.Player"/>
    [PublicAPI]
    public interface IPlayerFragmentArguments<out T> : IVariableHolder<T>
    {
    }

    /// <summary>
    /// Class with extension methods for <see cref="IPlayerFragmentArguments{T}"/>.
    /// </summary>
    [PublicAPI]
    public static class PlayerFragmentArguments
    {
        /// <summary>
        /// Sets the request to include the linking code with the player.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithLinkingCode<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withLinkingCode", true);
        }
        
        /// <summary>
        /// Sets the request to include the URL to the QR linking code with the player.
        /// </summary>
        /// <param name="instance">The caller.</param>
        /// <typeparam name="T">The caller type.</typeparam>
        /// <returns>The caller for chaining.</returns>
        public static T WithLinkingCodeQr<T>(this T instance) where T : IPlayerFragmentArguments<T>
        {
            return instance.SetVariable("withLinkingCodeQr", true);
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
        /// Sets the desired size of the QR image in pixels.
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
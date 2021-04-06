using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// The networks hosts used by the Enjin Cloud.
    /// </summary>
    [PublicAPI]
    public class EnjinHosts
    {
        /// <summary>
        /// The URI for the kovan Enjin Cloud.
        /// </summary>
        public static readonly Uri KOVAN = new Uri("https://kovan.cloud.enjin.io/");
        
        /// <summary>
        /// The URI for the main Enjin Cloud.
        /// </summary>
        public static readonly Uri MAIN_NET = new Uri("https://cloud.enjin.io/");

        /// <summary>
        /// The URI for the JumpNet network.
        /// </summary>
        public static readonly Uri JUMP_NET = new Uri("https://jumpnet.cloud.enjin.io/");
    }
}
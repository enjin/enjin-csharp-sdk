using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class EnjinHosts
    {
        public static readonly Uri KOVAN = new Uri("https://kovan.cloud.enjin.io/");
        public static readonly Uri MAIN_NET = new Uri("https://cloud.enjin.io/");
    }
}
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public interface ITrustedPlatformClient
    {
        TrustedPlatformMiddleware Middleware { get; }
        
        ISharedSchema Schema { get; }
    }
}
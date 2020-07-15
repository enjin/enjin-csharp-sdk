using Enjin.SDK.PlayerSchema;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public interface IPlayerClient : ITrustedPlatformClient
    {
        new IPlayerSchema Schema { get; }
    }
}
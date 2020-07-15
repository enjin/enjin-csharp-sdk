using Enjin.SDK.ProjectSchema;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public interface IProjectClient : ITrustedPlatformClient
    {
        new IProjectSchema Schema { get; }
    }
}
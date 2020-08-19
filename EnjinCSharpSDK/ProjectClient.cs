using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class ProjectClient : ProjectSchema.ProjectSchema
    {
        public ProjectClient(Uri baseUri, bool debug = false)
            : base(new TrustedPlatformMiddleware(baseUri, debug))
        {
        }
    }
}
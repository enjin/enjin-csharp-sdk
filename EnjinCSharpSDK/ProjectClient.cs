using System;
using Enjin.SDK.ProjectSchema;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class ProjectClient : TrustedPlatformClient
    {
        public new IProjectSchema Schema { get; }

        public ProjectClient(Uri baseUri, bool debug) : base(baseUri, debug, "app")
        {
        }
    }
}
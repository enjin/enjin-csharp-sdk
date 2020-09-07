using System;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Client for using the project schema.
    /// </summary>
    /// <seealso cref="EnjinHosts"/>
    [PublicAPI]
    public class ProjectClient : ProjectSchema.ProjectSchema
    {
        /// <summary>
        /// Constructs a client with the targeted URI.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        public ProjectClient(Uri baseUri, bool debug = false)
            : base(new TrustedPlatformMiddleware(baseUri, debug))
        {
        }
    }
}
using System;
using Enjin.SDK.ProjectSchema;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    [PublicAPI]
    public class ProjectClient : TrustedPlatformClient
    {
        private const string SCHEMA = "app";
        
        public ProjectClient(Uri baseUri, bool debug = false) : base(baseUri, debug, SCHEMA)
        {
        }
        
        public IProjectSchema Schema => SchemaInstance;
    }
}
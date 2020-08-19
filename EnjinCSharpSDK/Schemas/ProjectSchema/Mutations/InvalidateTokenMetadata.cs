using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class InvalidateTokenMetadata : GraphqlRequest<InvalidateTokenMetadata>
    {
        public InvalidateTokenMetadata() : base("enjin.sdk.project.InvalidateTokenMetadata")
        {
        }
        
        public InvalidateTokenMetadata Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
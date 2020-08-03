using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class InvalidateTokenMetadata<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        protected InvalidateTokenMetadata() : base("enjin.sdk.project.InvalidateTokenMetadata")
        {
        }
        
        public T Id(string id)
        {
            return SetVariable("id", id);
        }
    }

    [PublicAPI]
    public class InvalidateTokenMetadata : InvalidateTokenMetadata<InvalidateTokenMetadata>
    {
    }
}
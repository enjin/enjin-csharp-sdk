using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class DeletePlayer<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        public T Id(string id)
        {
            return SetVariable("id", id);
        }
    }

    [PublicAPI]
    public class DeletePlayer : DeletePlayer<DeletePlayer>
    {
    }
}
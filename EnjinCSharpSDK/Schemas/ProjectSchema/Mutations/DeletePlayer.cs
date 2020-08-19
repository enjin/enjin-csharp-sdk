using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class DeletePlayer : GraphqlRequest<DeletePlayer>
    {
        public DeletePlayer() : base("enjin.sdk.project.DeletePlayer")
        {
        }
        
        public DeletePlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}
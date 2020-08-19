using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetProject : GraphqlRequest<GetProject>
    {
        public GetProject() : base("enjin.sdk.shared.GetProject")
        {
        }

        public GetProject Id(int? id)
        {
            return SetVariable("id", id);
        }

        public GetProject Name(string name)
        {
            return SetVariable("name", name);
        }
    }
}
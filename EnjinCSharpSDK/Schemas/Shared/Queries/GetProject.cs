using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetProject<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        protected GetProject() : base("enjin.sdk.shared.GetProject")
        {
        }

        public T Id(int id)
        {
            return SetVariable("id", id);
        }

        public T Name(string name)
        {
            return SetVariable("name", name);
        }
    }
    
    [PublicAPI]
    public class GetProject : GetProject<GetProject>
    {}
}
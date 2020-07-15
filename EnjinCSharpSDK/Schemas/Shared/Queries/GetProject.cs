using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetProject<T> : GraphqlRequest<T>, IProjectFragmentArguments<T> where T : GraphqlRequest<T>, new()
    {
        internal GetProject()
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
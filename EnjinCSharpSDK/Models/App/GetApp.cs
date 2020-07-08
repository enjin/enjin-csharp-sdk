using System.Collections.Generic;
using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class GetApp<T> : GraphqlRequest<T>, IAppFragment<T> where T : GraphqlRequest<T>, new()
    {
        internal GetApp()
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
    public class GetApp : GetApp<GetApp>
    {}
}
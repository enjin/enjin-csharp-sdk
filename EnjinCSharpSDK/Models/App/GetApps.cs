using System.Collections.Generic;
using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class GetApps<T> : PaginationRequest<T>, IAppFragment<T> where T : PaginationRequest<T>, new()
    {
        internal GetApps()
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
    public class GetApps : GetApps<GetApps>
    {}
}
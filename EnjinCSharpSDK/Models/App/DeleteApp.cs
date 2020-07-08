using System.Collections.Generic;
using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class DeleteApp<T> : GraphqlRequest<T>, IAppFragment<T> where T : GraphqlRequest<T>, new()
    {
        internal DeleteApp()
        {
        }

        public T Id(int id)
        {
            return SetVariable("id", id);
        }
    }

    [PublicAPI]
    public class DeleteApp : DeleteApp<DeleteApp>
    {
    }
}
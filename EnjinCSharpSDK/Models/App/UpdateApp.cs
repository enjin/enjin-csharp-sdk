using System.Collections.Generic;
using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class UpdateApp<T> : GraphqlRequest<T>, IAppFragment<T> where T : GraphqlRequest<T>, new()
    {
        internal UpdateApp()
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

        public T Description(string description)
        {
            return SetVariable("description", description);
        }

        public T Image(string image)
        {
            return SetVariable("image", image);
        }

        public T Options(AppOptions options)
        {
            return SetVariable("options", options);
        }
    }

    [PublicAPI]
    public class UpdateApp : UpdateApp<UpdateApp>
    {
    }
}
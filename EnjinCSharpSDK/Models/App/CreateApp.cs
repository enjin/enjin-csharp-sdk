using System.Collections.Generic;
using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class CreateApp<T> : GraphqlRequest<T>, IAppFragment<T> where T : GraphqlRequest<T>, new()
    {
        internal CreateApp()
        {
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
    }

    [PublicAPI]
    public class CreateApp : CreateApp<CreateApp>
    {
    }
}
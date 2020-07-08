using System.Collections.Generic;
using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class UnlinkApp<T> : GraphqlRequest<T>, IAppFragment<T> where T : GraphqlRequest<T>, new()
    {
        internal UnlinkApp()
        {
        }

        public T Id(int id)
        {
            return SetVariable("id", id);
        }

        public T EthAddress(string address)
        {
            return SetVariable("ethAddress", address);
        }
    }

    [PublicAPI]
    public class UnlinkApp : UnlinkApp<UnlinkApp>
    {
    }
}
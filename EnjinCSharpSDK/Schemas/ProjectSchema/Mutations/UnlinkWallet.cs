using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class UnlinkWallet<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        protected UnlinkWallet() : base("enjin.sdk.project.UnlinkWallet")
        {
        }
        
        public T EthAddress(string ethAddress)
        {
            return SetVariable("ethAddress", ethAddress);
        }
    }
    
    [PublicAPI]
    public class UnlinkWallet : UnlinkWallet<UnlinkWallet>
    {}
}
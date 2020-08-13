using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class UnlinkWallet : GraphqlRequest<UnlinkWallet>
    {
        protected UnlinkWallet() : base("enjin.sdk.project.UnlinkWallet")
        {
        }
        
        public UnlinkWallet EthAddress(string ethAddress)
        {
            return SetVariable("ethAddress", ethAddress);
        }
    }
}
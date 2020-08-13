using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class ReleaseReserve : GraphqlRequest<ReleaseReserve>, ITransactionRequestArguments<ReleaseReserve>
    {
        public ReleaseReserve() : base("enjin.sdk.project.ReleaseReserve")
        {
        }
        
        public ReleaseReserve TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public ReleaseReserve Value(string value)
        {
            return SetVariable("value", value);
        }
    }
}
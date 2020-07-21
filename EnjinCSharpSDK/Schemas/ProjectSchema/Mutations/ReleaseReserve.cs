using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class ReleaseReserve<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T Value(string value)
        {
            return SetVariable("value", value);
        }
    }

    [PublicAPI]
    public class ReleaseReserve : ReleaseReserve<ReleaseReserve>
    {
    }
}
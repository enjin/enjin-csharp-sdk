using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetRequest<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected GetRequest() : base("enjin.sdk.shared.GetRequest")
        {
        }

        public T Id(int id)
        {
            return SetVariable("id", id);
        }

        public T TransactionId(string id)
        {
            return SetVariable("transactionId", id);
        }
    }
    
    [PublicAPI]
    public class GetRequest : GetRequest<GetRequest>
    {}
}
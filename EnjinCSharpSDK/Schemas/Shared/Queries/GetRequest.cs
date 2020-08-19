using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetRequest : GraphqlRequest<GetRequest>, ITransactionFragmentArguments<GetRequest>
    {
        public GetRequest() : base("enjin.sdk.shared.GetRequest")
        {
        }

        public GetRequest Id(int? id)
        {
            return SetVariable("id", id);
        }

        public GetRequest TransactionId(string id)
        {
            return SetVariable("transactionId", id);
        }
    }
}
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class AdvancedSendToken<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected AdvancedSendToken() : base("enjin.sdk.shared.AdvancedSendToken")
        {
        }

        public T Transfers(params Transfer[] transfers)
        {
            return SetVariable("transfers", transfers);
        }

        public T Data(string data)
        {
            return SetVariable("data", data);
        }
    }
    
    [PublicAPI]
    public class AdvancedSendToken : AdvancedSendToken<AdvancedSendToken>
    {}
}
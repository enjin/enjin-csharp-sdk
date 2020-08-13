using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class AdvancedSendToken : GraphqlRequest<AdvancedSendToken>, ITransactionRequestArguments<AdvancedSendToken>
    {
        protected AdvancedSendToken() : base("enjin.sdk.shared.AdvancedSendToken")
        {
        }

        public AdvancedSendToken Transfers(params Transfer[] transfers)
        {
            return SetVariable("transfers", transfers);
        }

        public AdvancedSendToken Data(string data)
        {
            return SetVariable("data", data);
        }
    }
}
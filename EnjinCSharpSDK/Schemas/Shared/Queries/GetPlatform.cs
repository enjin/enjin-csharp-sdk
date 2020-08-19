using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetPlatform : GraphqlRequest<GetPlatform>
    {
        public GetPlatform() : base("enjin.sdk.shared.GetPlatform")
        {
        }
        
        public GetPlatform WithContracts()
        {
            return SetVariable("withContracts", true);
        }

        public GetPlatform WithNotificationDrivers()
        {
            return SetVariable("withNotificationDrivers", true);
        }
    }
}
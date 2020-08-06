using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetPlatform<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        protected GetPlatform() : base("enjin.sdk.shared.GetPlatform")
        {
        }
        
        public T WithContracts()
        {
            return SetVariable("withContracts", true);
        }

        public T WithNotificationDrivers()
        {
            return SetVariable("withNotificationDrivers", true);
        }
    }
    
    [PublicAPI]
    public class GetPlatform : GetPlatform<GetPlatform>
    {}
}
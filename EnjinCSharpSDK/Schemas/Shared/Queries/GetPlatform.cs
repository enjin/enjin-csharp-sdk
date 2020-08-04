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
        
        public T WithContracts(bool value)
        {
            return SetVariable("withContracts", value);
        }

        public T WithNotificationDrivers(bool value)
        {
            return SetVariable("withNotificationDrivers", value);
        }
    }
    
    [PublicAPI]
    public class GetPlatform : GetPlatform<GetPlatform>
    {}
}
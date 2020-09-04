using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting the platform details.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Platform"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetPlatform : GraphqlRequest<GetPlatform>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetPlatform() : base("enjin.sdk.shared.GetPlatform")
        {
        }
        
        /// <summary>
        /// Sets the request to include the contracts with the platform.
        /// </summary>
        /// <returns>This request for chaining.</returns>
        public GetPlatform WithContracts()
        {
            return SetVariable("withContracts", true);
        }

        /// <summary>
        /// Sets the request to include the notification drivers with the platform.
        /// </summary>
        /// <returns>This request for chaining.</returns>
        public GetPlatform WithNotificationDrivers()
        {
            return SetVariable("withNotificationDrivers", true);
        }
    }
}
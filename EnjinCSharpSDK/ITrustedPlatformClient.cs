using System;
using EnjinSDK.Services.App;

namespace EnjinSDK
{
    public interface ITrustedPlatformClient
    {
        TrustedPlatformMiddleware Middleware { get; }
        
        IAppService AppService { get;  }
    }
}
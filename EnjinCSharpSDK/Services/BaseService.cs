using System;
using EnjinSDK.Graphql;
using Newtonsoft.Json.Linq;

namespace EnjinSDK.Services
{
    public class BaseService
    {
        protected readonly TrustedPlatformMiddleware Middleware;
        
        public BaseService(TrustedPlatformMiddleware middleware)
        {
            Middleware = middleware;
        }
        
        protected JObject CreateRequestBody(IVariableHolder holder, string template)
        {
            var obj = new JObject
            {
                {"query", Middleware.Registry.GetOperationForName(template).CompiledContents},
                {"variables", JToken.FromObject(holder.Variables)}
            };
            Console.Out.WriteLine(obj);
            return obj;
        }
    }
}
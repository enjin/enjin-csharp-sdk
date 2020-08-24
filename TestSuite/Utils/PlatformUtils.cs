using System.Reflection;
using Enjin.SDK.Models;

namespace TestSuite.Utils
{
    public static class PlatformUtils
    {
        public static Platform CreatePlatform(string network = "kovan")
        {
            var platform = new Platform();

            var networkProperty = platform.GetType().GetProperty("Network");
            networkProperty?.SetValue(platform, network);
            
            return platform;
        }
    }
}
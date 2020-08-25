using Enjin.SDK.Models;

namespace TestSuite.Utils
{
    public static class PlatformUtils
    {
        public static readonly Platform KOVAN_PLATFORM;
        public static readonly Platform MAINNET_PLATFORM;

        static PlatformUtils()
        {
            KOVAN_PLATFORM = CreatePlatform("kovan");
            MAINNET_PLATFORM = CreatePlatform("mainnet");
        }
        
        public static Platform CreatePlatform(string network)
        {
            var platform = new Platform();

            var networkProperty = platform.GetType().GetProperty("Network");
            networkProperty?.SetValue(platform, network);
            
            return platform;
        }
    }
}
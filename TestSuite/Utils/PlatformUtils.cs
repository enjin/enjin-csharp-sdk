using System.Text;
using Enjin.SDK.Models;
using Newtonsoft.Json;

namespace TestSuite.Utils
{
    public static class PlatformUtils
    {
        public static Platform FakePlatform { get; } = CreateFakePlatform("fake");
        
        public static Platform CreateFakePlatform(string network)
        {
            return CreateFakePlatform(network, "a826ad9293ce1ae1a036", "mt1", true);
        }
        
        public static Platform CreateFakePlatform(string network,
                                                  string key,
                                                  string cluster,
                                                  bool encrypted)
        {
            var builder = new StringBuilder()
                          .Append(@"{""network"": ")
                          .Append($"'{network}'")
                          .Append(@", ""notifications"": {")
                          .Append(@"""pusher"": {")
                          .Append(@"""key"": ")
                          .Append($"'{key}'")
                          .Append(@", ""options"": {")
                          .Append(@"""cluster"": ")
                          .Append($"'{cluster}'")
                          .Append(@", ""encrypted"": ")
                          .Append($"'{encrypted}'")
                          .Append(@"}}}}");
            return JsonConvert.DeserializeObject<Platform>(builder.ToString());
        }
    }
}
/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
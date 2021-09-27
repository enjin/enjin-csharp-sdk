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

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Enjin.SDK.Events;
using Enjin.SDK.Models;
using Enjin.SDK.Utils;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class EventTypeDefTest
    {
        [TestCase("project")]
        [TestCase("enjincloud.kovan.wallet.0x0")]
        [TestCase("enjincloud.kovan.wallet.0x0", "enjincloud.kovan.asset.0x0")]
        public void FilterByChannelTypes_ReturnsDefsWithChannelType(params string[] channels)
        {
            // Arrange
            var defs = GetDefsByReflection();
            
            // Act
            var filteredDefs = EventTypeDef.FilterByChannelTypes(channels);

            // Assert
            foreach (var def in defs)
            {
                var expected = def.Channels.Any(defChannel => channels.Any(c => c.Contains(defChannel)));
                var actual = filteredDefs.Contains(def);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestCase("", ExpectedResult = EventType.UNKNOWN)]
        [TestCase("PROJECT_CREATED", ExpectedResult = EventType.PROJECT_CREATED)]
        public EventType GetFromName_ReturnDefWithCorrectType(string name)
        {
            // Act
            var def = EventTypeDef.GetFromName(name);

            // Assert
            return def.Type;
        }

        [TestCase("PROJECT_CREATED", ExpectedResult = "EnjinCloud\\Events\\ProjectCreated")]
        public string GetFromName_ReturnDefWithCorrectKey(string name)
        {
            // Act
            var def = EventTypeDef.GetFromName(name);

            // Assert
            return def.Key;
        }

        [TestCase("", ExpectedResult = EventType.UNKNOWN)]
        [TestCase("EnjinCloud\\Events\\ProjectCreated", ExpectedResult = EventType.PROJECT_CREATED)]
        public EventType GetFromKey_ReturnDefWithCorrectType(string key)
        {
            // Act
            var def = EventTypeDef.GetFromKey(key);

            // Assert
            return def.Type;
        }
        
        [TestCase("PROJECT_LINKED", EventType.PROJECT_LINKED)]
        public void In_DefIsInTypes(string name, params EventType[] types)
        {
            // Arrange
            var def = EventTypeDef.GetFromName(name);

            // Act
            var result = def.In(types);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("PROJECT_LINKED", EventType.PROJECT_UNLINKED)]
        public void In_DefIsNotInTypes(string name, params EventType[] types)
        {
            // Arrange
            var def = EventTypeDef.GetFromName(name);

            // Act
            var result = def.In(types);

            // Assert
            Assert.IsFalse(result);
        }
        
        private static IEnumerable<EventTypeDef> GetDefsByReflection()
        {
            var defs = new List<EventTypeDef>();
            
            typeof(EventTypeDef)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(f => f.GetValue(null) is EventTypeDef)
                .Select(f => f.GetValue(null) as EventTypeDef)
                .Do(v => defs.Add(v));

            return defs.ToArray();
        }
    }
}
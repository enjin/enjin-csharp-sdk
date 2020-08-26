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
        [Test]
        [TestCase("app")]
        public void FilterByChannelTypes_ReturnsDefsWithChannelType(params string[] channels)
        {
            // Arrange
            var defs = GetDefsByReflection();
            
            // Act
            var filteredDefs = EventTypeDef.FilterByChannelTypes(channels);

            // Assert
            foreach (var def in defs)
            {
                if (def.Channels.Any(channels.Contains))
                    Assert.IsTrue(filteredDefs.Contains(def));
                else
                    Assert.IsFalse(filteredDefs.Contains(def));
            }
        }

        [Test]
        [TestCase("", ExpectedResult = EventType.UNKNOWN)]
        [TestCase("APP_CREATED", ExpectedResult = EventType.APP_CREATED)]
        public EventType GetFromName_ReturnDefWithCorrectType(string name)
        {
            // Act
            var def = EventTypeDef.GetFromName(name);

            // Assert
            return def.Type;
        }

        [Test]
        [TestCase("APP_CREATED", ExpectedResult = "EnjinCloud\\Events\\AppCreated")]
        public string GetFromName_ReturnDefWithCorrectKey(string name)
        {
            // Act
            var def = EventTypeDef.GetFromName(name);

            // Assert
            return def.Key;
        }

        [Test]
        [TestCase("", ExpectedResult = EventType.UNKNOWN)]
        [TestCase("EnjinCloud\\Events\\AppCreated", ExpectedResult = EventType.APP_CREATED)]
        public EventType GetFromKey_ReturnDefWithCorrectType(string key)
        {
            // Act
            var def = EventTypeDef.GetFromKey(key);

            // Assert
            return def.Type;
        }
        
        [Test]
        [TestCase("APP_LINKED", EventType.APP_LINKED)]
        public void In_DefIsInTypes(string name, params EventType[] types)
        {
            // Arrange
            var def = EventTypeDef.GetFromName(name);

            // Act
            var result = def.In(types);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("APP_LINKED", EventType.APP_UNLINKED)]
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
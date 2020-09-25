using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherTest
    {
        private static readonly PusherChannels DEFAULT_CHANNELS = new PusherChannels();
        private static readonly PusherOptions DEFAULT_OPTIONS = new PusherOptions();
        
        [Test]
        public void Key_GetsValue()
        {
            // Arrange
            const string expected = FakePusher.DefaultKey;
            var pusher = CreateDefaultFakePusher();

            // Act
            var actual = pusher.Key;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Namespace_GetsValue()
        {
            // Arrange
            const string expected = FakePusher.DefaultNamespace;
            var pusher = CreateDefaultFakePusher();

            // Act
            var actual = pusher.Namespace;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Channels_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_CHANNELS;
            var pusher = CreateDefaultFakePusher();

            // Act
            var actual = pusher.Channels;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Options_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_OPTIONS;
            var pusher = CreateDefaultFakePusher();

            // Act
            var actual = pusher.Options;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Pusher CreateDefaultFakePusher() =>
            new FakePusher(channels: DEFAULT_CHANNELS, options: DEFAULT_OPTIONS);
        
        private class FakePusher : Pusher
        {
            public const string DefaultKey = "DefaultKey";
            public const string DefaultNamespace = "DefaultNamespace";
            
            private static readonly PropertyInfo KEY_PROPERTY;
            private static readonly PropertyInfo NAMESPACE_PROPERTY;
            private static readonly PropertyInfo CHANNELS_PROPERTY;
            private static readonly PropertyInfo OPTIONS_PROPERTY;

            static FakePusher()
            {
                var type = typeof(Pusher);
                KEY_PROPERTY = GetPublicProperty(type, "Key");
                NAMESPACE_PROPERTY = GetPublicProperty(type, "Namespace");
                CHANNELS_PROPERTY = GetPublicProperty(type, "Channels");
                OPTIONS_PROPERTY = GetPublicProperty(type, "Options");
            }

            public FakePusher(string key = DefaultKey,
                              string @namespace = DefaultNamespace,
                              PusherChannels channels = null,
                              PusherOptions options = null)
            {
                KEY_PROPERTY.SetValue(this, key);
                NAMESPACE_PROPERTY.SetValue(this, @namespace);
                CHANNELS_PROPERTY.SetValue(this, channels);
                OPTIONS_PROPERTY.SetValue(this, options);
            }
        }
    }
}
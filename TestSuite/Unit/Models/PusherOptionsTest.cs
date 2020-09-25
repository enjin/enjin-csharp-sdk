using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class PusherOptionsTest
    {
        [Test]
        public void Cluster_GetsValue()
        {
            // Arrange
            const string expected = FakePusherOptions.DefaultCluster;
            var options = CreateDefaultFakePusherOptions();

            // Act
            var actual = options.Cluster;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Encrypted_GetsValue()
        {
            // Arrange
            const bool expected = FakePusherOptions.DefaultEncrypted;
            var options = CreateDefaultFakePusherOptions();

            // Act
            var actual = options.Encrypted;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static PusherOptions CreateDefaultFakePusherOptions() => new FakePusherOptions();
        
        private class FakePusherOptions : PusherOptions
        {
            public const string DefaultCluster = "DefaultCluster";
            public const bool DefaultEncrypted = true;
            
            private static readonly PropertyInfo CLUSTER_PROPERTY;
            private static readonly PropertyInfo ENCRYPTED_PROPERTY;

            static FakePusherOptions()
            {
                var type = typeof(PusherOptions);
                CLUSTER_PROPERTY = GetPublicProperty(type, "Cluster");
                ENCRYPTED_PROPERTY = GetPublicProperty(type, "Encrypted");
            }

            public FakePusherOptions(string cluster = DefaultCluster, bool encrypted = DefaultEncrypted)
            {
                CLUSTER_PROPERTY.SetValue(this, cluster);
                ENCRYPTED_PROPERTY.SetValue(this, encrypted);
            }
        }
    }
}
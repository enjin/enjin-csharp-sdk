using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class BalanceTest
    {
        private static readonly Project DEFAULT_PROJECT = new Project();
        private static readonly Wallet DEFAULT_WALLET = new Wallet();

        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const string expected = FakeBalance.DefaultId;
            var balance = CreateDefaultFakeBalance();

            // Act
            var actual = balance.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Index_GetsValue()
        {
            // Arrange
            const string expected = FakeBalance.DefaultIndex;
            var balance = CreateDefaultFakeBalance();

            // Act
            var actual = balance.Index;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Value_GetsValue()
        {
            // Arrange
            const int expected = FakeBalance.DefaultValue;
            var balance = CreateDefaultFakeBalance();

            // Act
            var actual = balance.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Project_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_PROJECT;
            var balance = CreateDefaultFakeBalance();

            // Act
            var actual = balance.Project;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Wallet_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_WALLET;
            var balance = CreateDefaultFakeBalance();

            // Act
            var actual = balance.Wallet;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Balance CreateDefaultFakeBalance() =>
            new FakeBalance(project: DEFAULT_PROJECT, wallet: DEFAULT_WALLET);
        
        private class FakeBalance : Balance
        {
            public const string DefaultId = "DefaultId";
            public const string DefaultIndex = "DefaultIndex";
            public const int DefaultValue = 1;
            
            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo INDEX_PROPERTY;
            private static readonly PropertyInfo VALUE_PROPERTY;
            private static readonly PropertyInfo PROJECT_PROPERTY;
            private static readonly PropertyInfo WALLET_PROPERTY;

            static FakeBalance()
            {
                var type = typeof(Balance);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                INDEX_PROPERTY = GetPublicProperty(type, "Index");
                VALUE_PROPERTY = GetPublicProperty(type, "Value");
                PROJECT_PROPERTY = GetPublicProperty(type, "Project");
                WALLET_PROPERTY = GetPublicProperty(type, "Wallet");
            }

            public FakeBalance(string id = DefaultId,
                               string index = DefaultIndex,
                               int value = DefaultValue,
                               Project project = null,
                               Wallet wallet = null)
            {
                ID_PROPERTY.SetValue(this, id);
                INDEX_PROPERTY.SetValue(this, index);
                VALUE_PROPERTY.SetValue(this, value);
                PROJECT_PROPERTY.SetValue(this, project);
                WALLET_PROPERTY.SetValue(this, wallet);
            }
        }
    }
}
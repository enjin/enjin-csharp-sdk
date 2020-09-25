using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class WalletTest
    {
        private static readonly List<Token> DEFAULT_TOKENS_CREATED = new List<Token>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            DEFAULT_TOKENS_CREATED.Add(new Token());
            DEFAULT_TOKENS_CREATED.Add(new Token());
            DEFAULT_TOKENS_CREATED.Add(new Token());
        }

        [Test]
        public void EthAddress_GetsValue()
        {
            // Arrange
            const string expected = FakeWallet.DefaultEthAddress;
            var wallet = CreateDefaultFakeWallet();

            // Act
            var actual = wallet.EthAddress;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void EnjAllowance_GetsValue()
        {
            // Arrange
            const float expected = FakeWallet.DefaultEnjAllowance;
            var wallet = CreateDefaultFakeWallet();

            // Act
            var actual = wallet.EnjAllowance;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void EnjBalance_GetsValue()
        {
            // Arrange
            const float expected = FakeWallet.DefaultEnjBalance;
            var wallet = CreateDefaultFakeWallet();

            // Act
            var actual = wallet.EnjBalance;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void EthBalance_GetsValue()
        {
            // Arrange
            const float expected = FakeWallet.DefaultEthBalance;
            var wallet = CreateDefaultFakeWallet();

            // Act
            var actual = wallet.EthBalance;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokensCreated_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_TOKENS_CREATED;
            var wallet = CreateDefaultFakeWallet();

            // Act
            var actual = wallet.TokensCreated;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Wallet CreateDefaultFakeWallet() => new FakeWallet(tokensCreated: DEFAULT_TOKENS_CREATED);
        
        private class FakeWallet : Wallet
        {
            public const string DefaultEthAddress = "DefaultEthAddress";
            public const float DefaultEnjAllowance = 1.0f;
            public const float DefaultEnjBalance = 2.0f;
            public const float DefaultEthBalance = 3.0f;
            
            private static readonly PropertyInfo ETH_ADDRESS_PROPERTY;
            private static readonly PropertyInfo ENJ_ALLOWANCE_PROPERTY;
            private static readonly PropertyInfo ENJ_BALANCE_PROPERTY;
            private static readonly PropertyInfo ETH_BALANCE_PROPERTY;
            private static readonly PropertyInfo TOKENS_CREATED_PROPERTY;

            static FakeWallet()
            {
                var type = typeof(Wallet);
                ETH_ADDRESS_PROPERTY = GetPublicProperty(type, "EthAddress");
                ENJ_ALLOWANCE_PROPERTY = GetPublicProperty(type, "EnjAllowance");
                ENJ_BALANCE_PROPERTY = GetPublicProperty(type, "EnjBalance");
                ETH_BALANCE_PROPERTY = GetPublicProperty(type, "EthBalance");
                TOKENS_CREATED_PROPERTY = GetPublicProperty(type, "TokensCreated");
            }

            public FakeWallet(string ethAddress = DefaultEthAddress,
                              float enjAllowance = DefaultEnjAllowance,
                              float enjBalance = DefaultEnjBalance,
                              float ethBalance = DefaultEthBalance,
                              List<Token> tokensCreated = null)
            {
                ETH_ADDRESS_PROPERTY.SetValue(this, ethAddress);
                ENJ_ALLOWANCE_PROPERTY.SetValue(this, enjAllowance);
                ENJ_BALANCE_PROPERTY.SetValue(this, enjBalance);
                ETH_BALANCE_PROPERTY.SetValue(this, ethBalance);
                TOKENS_CREATED_PROPERTY.SetValue(this, tokensCreated);
            }
        }
    }
}
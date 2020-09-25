using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class AccessTokenTest
    {
        [Test]
        public void Token_GetsValue()
        {
            // Arrange
            const string expected = FakeAccessToken.DefaultToken;
            var accessToken = CreateDefaultFakeAccessToken();

            // Act
            var actual = accessToken.Token;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExpiresIn_GetsValue()
        {
            // Arrange
            const long expected = FakeAccessToken.DefaultExpiresIn;
            var accessToken = CreateDefaultFakeAccessToken();

            // Act
            var actual = accessToken.ExpiresIn;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ToString_Returns()
        {
            // Arrange
            var expected = $"Token: {FakeAccessToken.DefaultToken}, ExpiresIn: {FakeAccessToken.DefaultExpiresIn}";
            var accessToken = CreateDefaultFakeAccessToken();

            // Act
            var actual = accessToken.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static AccessToken CreateDefaultFakeAccessToken() => new FakeAccessToken();
        
        private class FakeAccessToken : AccessToken
        {
            public const string DefaultToken = "DefaultToken";
            public const long DefaultExpiresIn = 1L;
            
            private static readonly PropertyInfo TOKEN_PROPERTY;
            private static readonly PropertyInfo EXPIRES_IN_PROPERTY;

            static FakeAccessToken()
            {
                var type = typeof(AccessToken);
                TOKEN_PROPERTY = GetPublicProperty(type, "Token");
                EXPIRES_IN_PROPERTY = GetPublicProperty(type, "ExpiresIn");
            }

            public FakeAccessToken(string token = DefaultToken, long expiresIn = DefaultExpiresIn)
            {
                TOKEN_PROPERTY.SetValue(this, token);
                EXPIRES_IN_PROPERTY.SetValue(this, expiresIn);
            }
        }
    }
}
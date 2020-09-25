using System.Reflection;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TokenVariantTest
    {
        private static readonly JObject DEFAULT_VARIANT_METADATA = new JObject();

        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const int expected = FakeTokenVariant.DefaultId;
            var tokenVariant = CreateDefaultFakeTokenVariant();

            // Act
            var actual = tokenVariant.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenId_GetsValue()
        {
            // Arrange
            const string expected = FakeTokenVariant.DefaultTokenId;
            var tokenVariant = CreateDefaultFakeTokenVariant();

            // Act
            var actual = tokenVariant.TokenId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void VariantMetadata_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_VARIANT_METADATA;
            var tokenVariant = CreateDefaultFakeTokenVariant();

            // Act
            var actual = tokenVariant.VariantMetadata;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void UsageCount_GetsValue()
        {
            // Arrange
            const int expected = FakeTokenVariant.DefaultUsageCount;
            var tokenVariant = CreateDefaultFakeTokenVariant();

            // Act
            var actual = tokenVariant.UsageCount;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CreatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakeTokenVariant.DefaultCreatedAt;
            var tokenVariant = CreateDefaultFakeTokenVariant();

            // Act
            var actual = tokenVariant.CreatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void UpdatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakeTokenVariant.DefaultUpdatedAt;
            var tokenVariant = CreateDefaultFakeTokenVariant();

            // Act
            var actual = tokenVariant.UpdatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static TokenVariant CreateDefaultFakeTokenVariant() =>
            new FakeTokenVariant(variantMetadata: DEFAULT_VARIANT_METADATA);
        
        private class FakeTokenVariant : TokenVariant
        {
            public const int DefaultId = 1;
            public const string DefaultTokenId = "DefaultTokenId";
            public const int DefaultUsageCount = 2;
            public const string DefaultCreatedAt = "DefaultCreatedAt";
            public const string DefaultUpdatedAt = "DefaultUpdatedAt";
            
            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo TOKEN_ID_PROPERTY;
            private static readonly PropertyInfo VARIANT_METADATA_PROPERTY;
            private static readonly PropertyInfo USAGE_COUNT_PROPERTY;
            private static readonly PropertyInfo CREATED_AT_PROPERTY;
            private static readonly PropertyInfo UPDATED_AT_PROPERTY;

            static FakeTokenVariant()
            {
                var type = typeof(TokenVariant);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                TOKEN_ID_PROPERTY = GetPublicProperty(type, "TokenId");
                VARIANT_METADATA_PROPERTY = GetPublicProperty(type, "VariantMetadata");
                USAGE_COUNT_PROPERTY = GetPublicProperty(type, "UsageCount");
                CREATED_AT_PROPERTY = GetPublicProperty(type, "CreatedAt");
                UPDATED_AT_PROPERTY = GetPublicProperty(type, "UpdatedAt");
            }

            public FakeTokenVariant(int id = DefaultId,
                                    string tokenId = DefaultTokenId,
                                    JObject variantMetadata = null,
                                    int usageCount = DefaultUsageCount,
                                    string createdAt = DefaultCreatedAt,
                                    string updatedAt = DefaultUpdatedAt)
            {
                ID_PROPERTY.SetValue(this, id);
                TOKEN_ID_PROPERTY.SetValue(this, tokenId);
                VARIANT_METADATA_PROPERTY.SetValue(this, variantMetadata);
                USAGE_COUNT_PROPERTY.SetValue(this, usageCount);
                CREATED_AT_PROPERTY.SetValue(this, createdAt);
                UPDATED_AT_PROPERTY.SetValue(this, updatedAt);
            }
        }
    }
}
using System.Collections.Generic;
using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class TokenTest
    {
        private static readonly TokenTransferFeeSettings DEFAULT_TRANSFER_FEE_SETTINGS = new TokenTransferFeeSettings();
        private static readonly List<TokenVariant> DEFAULT_VARIANTS = new List<TokenVariant>();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            DEFAULT_VARIANTS.Add(new TokenVariant());
            DEFAULT_VARIANTS.Add(new TokenVariant());
            DEFAULT_VARIANTS.Add(new TokenVariant());
        }

        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultId;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Name_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultName;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void BlockHeight_GetsValue()
        {
            // Arrange
            const int expected = FakeToken.DefaultBlockHeight;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.BlockHeight;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Creator_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultCreator;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Creator;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void FirstBlock_GetsValue()
        {
            // Arrange
            const int expected = FakeToken.DefaultFirstBlock;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.FirstBlock;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MeltFeeRatio_GetsValue()
        {
            // Arrange
            const int expected = FakeToken.DefaultMeltFeeRatio;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.MeltFeeRatio;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MeltFeeMaxRatio_GetsValue()
        {
            // Arrange
            const int expected = FakeToken.DefaultMeltFeeMaxRatio;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.MeltFeeMaxRatio;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MeltValue_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultMeltValue;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.MeltValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MetadataUri_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultMetadataUri;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.MetadataUri;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Nonfungible_GetsValue()
        {
            // Arrange
            const bool expected = FakeToken.DefaultNonfungible;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Nonfungible;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Reserve_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultReserve;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Reserve;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SupplyModel_GetsValue()
        {
            // Arrange
            const TokenSupplyModel expected = FakeToken.DefaultSupplyModel;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.SupplyModel;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CirculatingSupply_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultCirculatingSupply;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.CirculatingSupply;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MintableSupply_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultMintableSupply;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.MintableSupply;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TotalSupply_GetsValue()
        {
            // Arrange
            const string expected = FakeToken.DefaultTotalSupply;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.TotalSupply;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Transferable_GetsValue()
        {
            // Arrange
            const TokenTransferable expected = FakeToken.DefaultTransferable;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Transferable;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TransferFeeSettings_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_TRANSFER_FEE_SETTINGS;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.TransferFeeSettings;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void VariantMode_GetsValue()
        {
            // Arrange
            const TokenVariantMode expected = FakeToken.DefaultVariantMode;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.VariantMode;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Variants_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_VARIANTS;
            var token = CreateDefaultFakeToken();

            // Act
            var actual = token.Variants;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        private static Token CreateDefaultFakeToken() =>
            new FakeToken(transferFeeSettings: DEFAULT_TRANSFER_FEE_SETTINGS, variants: DEFAULT_VARIANTS);

        private class FakeToken : Token
        {
            public const string DefaultId = "DefaultId";
            public const string DefaultName = "DefaultName";
            public const int DefaultBlockHeight = 1;
            public const string DefaultCreator = "DefaultCreator";
            public const int DefaultFirstBlock = 2;
            public const int DefaultMeltFeeRatio = 3;
            public const int DefaultMeltFeeMaxRatio = 4;
            public const string DefaultMeltValue = "DefaultMeltValue";
            public const string DefaultMetadataUri = "DefaultMetadataUri";
            public const bool DefaultNonfungible = true;
            public const string DefaultReserve = "DefaultReserve";
            public const TokenSupplyModel DefaultSupplyModel = TokenSupplyModel.FIXED;
            public const string DefaultCirculatingSupply = "DefaultCirculatingSupply";
            public const string DefaultMintableSupply = "DefaultMintableSupply";
            public const string DefaultTotalSupply = "DefaultTotalSupply";
            public const TokenTransferable DefaultTransferable = TokenTransferable.PERMANENT;
            public const TokenVariantMode DefaultVariantMode = TokenVariantMode.NONE;

            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo NAME_PROPERTY;
            private static readonly PropertyInfo BLOCK_HEIGHT_PROPERTY;
            private static readonly PropertyInfo CREATOR_PROPERTY;
            private static readonly PropertyInfo FIRST_BLOCK_PROPERTY;
            private static readonly PropertyInfo MELT_FEE_RATIO_PROPERTY;
            private static readonly PropertyInfo MELT_FEE_MAX_RATIO_PROPERTY;
            private static readonly PropertyInfo MELT_VALUE_PROPERTY;
            private static readonly PropertyInfo METADATA_URI_PROPERTY;
            private static readonly PropertyInfo NONFUNGIBLE_PROPERTY;
            private static readonly PropertyInfo RESERVE_PROPERTY;
            private static readonly PropertyInfo SUPPLY_MODEL_PROPERTY;
            private static readonly PropertyInfo CIRCULATING_SUPPLY_PROPERTY;
            private static readonly PropertyInfo MINTABLE_SUPPLY_PROPERTY;
            private static readonly PropertyInfo TOTAL_SUPPLY_PROPERTY;
            private static readonly PropertyInfo TRANSFERABLE_PROPERTY;
            private static readonly PropertyInfo TRANSFER_FEE_SETTINGS_PROPERTY;
            private static readonly PropertyInfo VARIANT_MODE_PROPERTY;
            private static readonly PropertyInfo VARIANTS_PROPERTY;

            static FakeToken()
            {
                var type = typeof(Token);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                NAME_PROPERTY = GetPublicProperty(type, "Name");
                BLOCK_HEIGHT_PROPERTY = GetPublicProperty(type, "BlockHeight");
                CREATOR_PROPERTY = GetPublicProperty(type, "Creator");
                FIRST_BLOCK_PROPERTY = GetPublicProperty(type, "FirstBlock");
                MELT_FEE_RATIO_PROPERTY = GetPublicProperty(type, "MeltFeeRatio");
                MELT_FEE_MAX_RATIO_PROPERTY = GetPublicProperty(type, "MeltFeeMaxRatio");
                MELT_VALUE_PROPERTY = GetPublicProperty(type, "MeltValue");
                METADATA_URI_PROPERTY = GetPublicProperty(type, "MetadataUri");
                NONFUNGIBLE_PROPERTY = GetPublicProperty(type, "Nonfungible");
                RESERVE_PROPERTY = GetPublicProperty(type, "Reserve");
                SUPPLY_MODEL_PROPERTY = GetPublicProperty(type, "SupplyModel");
                CIRCULATING_SUPPLY_PROPERTY = GetPublicProperty(type, "CirculatingSupply");
                MINTABLE_SUPPLY_PROPERTY = GetPublicProperty(type, "MintableSupply");
                TOTAL_SUPPLY_PROPERTY = GetPublicProperty(type, "TotalSupply");
                TRANSFERABLE_PROPERTY = GetPublicProperty(type, "Transferable");
                TRANSFER_FEE_SETTINGS_PROPERTY = GetPublicProperty(type, "TransferFeeSettings");
                VARIANT_MODE_PROPERTY = GetPublicProperty(type, "VariantMode");
                VARIANTS_PROPERTY = GetPublicProperty(type, "Variants");
            }

            public FakeToken(string id = DefaultId,
                             string name = DefaultName,
                             int blockHeight = DefaultBlockHeight,
                             string creator = DefaultCreator,
                             int firstBlock = DefaultFirstBlock,
                             int meltFeeRatio = DefaultMeltFeeRatio,
                             int meltFeeMaxRatio = DefaultMeltFeeMaxRatio,
                             string meltValue = DefaultMeltValue,
                             string metadataUri = DefaultMetadataUri,
                             bool nonfungible = DefaultNonfungible,
                             string reserve = DefaultReserve,
                             TokenSupplyModel supplyModel = DefaultSupplyModel,
                             string circulatingSupply = DefaultCirculatingSupply,
                             string mintableSupply = DefaultMintableSupply,
                             string totalSupply = DefaultTotalSupply,
                             TokenTransferable transferable = DefaultTransferable,
                             TokenTransferFeeSettings transferFeeSettings = null,
                             TokenVariantMode variantMode = DefaultVariantMode,
                             List<TokenVariant> variants = null)
            {
                ID_PROPERTY.SetValue(this, id);
                NAME_PROPERTY.SetValue(this, name);
                BLOCK_HEIGHT_PROPERTY.SetValue(this, blockHeight);
                CREATOR_PROPERTY.SetValue(this, creator);
                FIRST_BLOCK_PROPERTY.SetValue(this, firstBlock);
                MELT_FEE_RATIO_PROPERTY.SetValue(this, meltFeeRatio);
                MELT_FEE_MAX_RATIO_PROPERTY.SetValue(this, meltFeeMaxRatio);
                MELT_VALUE_PROPERTY.SetValue(this, meltValue);
                METADATA_URI_PROPERTY.SetValue(this, metadataUri);
                NONFUNGIBLE_PROPERTY.SetValue(this, nonfungible);
                RESERVE_PROPERTY.SetValue(this, reserve);
                SUPPLY_MODEL_PROPERTY.SetValue(this, supplyModel);
                CIRCULATING_SUPPLY_PROPERTY.SetValue(this, circulatingSupply);
                MINTABLE_SUPPLY_PROPERTY.SetValue(this, mintableSupply);
                TOTAL_SUPPLY_PROPERTY.SetValue(this, totalSupply);
                TRANSFERABLE_PROPERTY.SetValue(this, transferable);
                TRANSFER_FEE_SETTINGS_PROPERTY.SetValue(this, transferFeeSettings);
                VARIANT_MODE_PROPERTY.SetValue(this, variantMode);
                VARIANTS_PROPERTY.SetValue(this, variants);
            }
        }
    }
}
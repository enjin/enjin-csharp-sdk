﻿using Enjin.SDK.ProjectSchema;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class DecreaseMaxTransferFeeTest
    {
        [Test]
        public void TokenId_ContainsValue()
        {
            // Arrange
            const string key = "tokenId";
            const string expected = "0";
            var request = new DecreaseMaxTransferFee();

            // Act
            request.TokenId(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TokenIndex_ContainsValue()
        {
            // Arrange
            const string key = "tokenIndex";
            const string expected = "0";
            var request = new DecreaseMaxTransferFee();

            // Act
            request.TokenIndex(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MaxTransferFee_ContainsValue()
        {
            // Arrange
            const string key = "maxTransferFee";
            const int expected = 1;
            var request = new DecreaseMaxTransferFee();

            // Act
            request.MaxTransferFee(expected);
            var actual = request.Variables[key];

            // Assert
            Assert.IsTrue(request.IsSet(key));
            Assert.AreEqual(expected, actual);
        }
    }
}
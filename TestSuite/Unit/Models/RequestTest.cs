using System.Reflection;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class RequestTest
    {
        private static readonly JObject DEFAULT_RECEIPT = new JObject();

        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const int expected = FakeRequest.DefaultId;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TransactionId_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultTransactionId;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.TransactionId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Title_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultTitle;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contract_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultContract;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Contract;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EncodedData_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultEncodedData;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.EncodedData;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Type_GetsValue()
        {
            // Arrange
            const RequestType expected = FakeRequest.DefaultType;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Type;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Icon_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultIcon;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Icon;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Value_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultValue;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SignedTransaction_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultSignedTransaction;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.SignedTransaction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SignedBackupTransaction_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultSignedBackupTransaction;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.SignedBackupTransaction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SignedCancelTransaction_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultSignedCancelTransaction;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.SignedCancelTransaction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Error_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultError;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Error;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Nonce_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultNonce;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Nonce;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RetryState_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultRetryState;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.RetryState;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void State_GetsValue()
        {
            // Arrange
            const RequestState expected = FakeRequest.DefaultState;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.State;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Accepted_GetsValue()
        {
            // Arrange
            const bool expected = FakeRequest.DefaultAccepted;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Accepted;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Receipt_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_RECEIPT;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.Receipt;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TokenId_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultTokenId;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.TokenId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultCreatedAt;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.CreatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakeRequest.DefaultUpdatedAt;
            var request = CreateDefaultFakeRequest();

            // Act
            var actual = request.UpdatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static Request CreateDefaultFakeRequest() => new FakeRequest(receipt: DEFAULT_RECEIPT);

        private class FakeRequest : Request
        {
            public const int DefaultId = 1;
            public const string DefaultTransactionId = "DefaultTransactionId";
            public const string DefaultTitle = "DefaultTitle";
            public const string DefaultContract = "DefaultContract";
            public const string DefaultEncodedData = "DefaultEncodedData";
            public const RequestType DefaultType = RequestType.APPROVE;
            public const string DefaultIcon = "DefaultIcon";
            public const string DefaultValue = "DefaultValue";
            public const string DefaultSignedTransaction = "DefaultSignedTransaction";
            public const string DefaultSignedBackupTransaction = "DefaultSignedBackupTransaction";
            public const string DefaultSignedCancelTransaction = "DefaultSignedCancelTransaction";
            public const string DefaultError = "DefaultError";
            public const string DefaultNonce = "DefaultNonce";
            public const string DefaultRetryState = "DefaultRetryState";
            public const RequestState DefaultState = RequestState.EXECUTED;
            public const bool DefaultAccepted = true;
            public const string DefaultTokenId = "DefaultTokenId";
            public const string DefaultCreatedAt = "DefaultCreatedAt";
            public const string DefaultUpdatedAt = "DefaultUpdatedAt";

            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo TRANSACTION_ID_PROPERTY;
            private static readonly PropertyInfo TITLE_PROPERTY;
            private static readonly PropertyInfo CONTRACT_PROPERTY;
            private static readonly PropertyInfo ENCODED_DATA_PROPERTY;
            private static readonly PropertyInfo TYPE_PROPERTY;
            private static readonly PropertyInfo ICON_PROPERTY;
            private static readonly PropertyInfo VALUE_PROPERTY;
            private static readonly PropertyInfo SIGNED_TRANSACTION_PROPERTY;
            private static readonly PropertyInfo SIGNED_BACKUP_TRANSACTION_PROPERTY;
            private static readonly PropertyInfo SIGNED_CANCEL_TRANSACTION_PROPERTY;
            private static readonly PropertyInfo ERROR_PROPERTY;
            private static readonly PropertyInfo NONCE_PROPERTY;
            private static readonly PropertyInfo RETRY_STATE_PROPERTY;
            private static readonly PropertyInfo STATE_PROPERTY;
            private static readonly PropertyInfo ACCEPTED_PROPERTY;
            private static readonly PropertyInfo RECEIPT_PROPERTY;
            private static readonly PropertyInfo TOKEN_ID_PROPERTY;
            private static readonly PropertyInfo CREATED_AT_PROPERTY;
            private static readonly PropertyInfo UPDATED_AT_PROPERTY;

            static FakeRequest()
            {
                var type = typeof(Request);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                TRANSACTION_ID_PROPERTY = GetPublicProperty(type, "TransactionId");
                TITLE_PROPERTY = GetPublicProperty(type, "Title");
                CONTRACT_PROPERTY = GetPublicProperty(type, "Contract");
                ENCODED_DATA_PROPERTY = GetPublicProperty(type, "EncodedData");
                TYPE_PROPERTY = GetPublicProperty(type, "Type");
                ICON_PROPERTY = GetPublicProperty(type, "Icon");
                VALUE_PROPERTY = GetPublicProperty(type, "Value");
                SIGNED_TRANSACTION_PROPERTY = GetPublicProperty(type, "SignedTransaction");
                SIGNED_BACKUP_TRANSACTION_PROPERTY = GetPublicProperty(type, "SignedBackupTransaction");
                SIGNED_CANCEL_TRANSACTION_PROPERTY = GetPublicProperty(type, "SignedCancelTransaction");
                ERROR_PROPERTY = GetPublicProperty(type, "Error");
                NONCE_PROPERTY = GetPublicProperty(type, "Nonce");
                RETRY_STATE_PROPERTY = GetPublicProperty(type, "RetryState");
                STATE_PROPERTY = GetPublicProperty(type, "State");
                ACCEPTED_PROPERTY = GetPublicProperty(type, "Accepted");
                RECEIPT_PROPERTY = GetPublicProperty(type, "Receipt");
                TOKEN_ID_PROPERTY = GetPublicProperty(type, "TokenId");
                CREATED_AT_PROPERTY = GetPublicProperty(type, "CreatedAt");
                UPDATED_AT_PROPERTY = GetPublicProperty(type, "UpdatedAt");
            }

            public FakeRequest(int id = DefaultId,
                               string transactionId = DefaultTransactionId,
                               string title = DefaultTitle,
                               string contract = DefaultContract,
                               string encodedData = DefaultEncodedData,
                               RequestType type = DefaultType,
                               string icon = DefaultIcon,
                               string value = DefaultValue,
                               string signedTransaction = DefaultSignedTransaction,
                               string signedBackupTransaction = DefaultSignedBackupTransaction,
                               string signedCancelTransaction = DefaultSignedCancelTransaction,
                               string error = DefaultError,
                               string nonce = DefaultNonce,
                               string retryState = DefaultRetryState,
                               RequestState state = DefaultState,
                               bool accepted = DefaultAccepted,
                               JObject receipt = null,
                               string tokenId = DefaultTokenId,
                               string createdAt = DefaultCreatedAt,
                               string updatedAt = DefaultUpdatedAt)
            {
                ID_PROPERTY.SetValue(this, id);
                TRANSACTION_ID_PROPERTY.SetValue(this, transactionId);
                TITLE_PROPERTY.SetValue(this, title);
                CONTRACT_PROPERTY.SetValue(this, contract);
                ENCODED_DATA_PROPERTY.SetValue(this, encodedData);
                TYPE_PROPERTY.SetValue(this, type);
                ICON_PROPERTY.SetValue(this, icon);
                VALUE_PROPERTY.SetValue(this, value);
                SIGNED_TRANSACTION_PROPERTY.SetValue(this, signedTransaction);
                SIGNED_BACKUP_TRANSACTION_PROPERTY.SetValue(this, signedBackupTransaction);
                SIGNED_CANCEL_TRANSACTION_PROPERTY.SetValue(this, signedCancelTransaction);
                ERROR_PROPERTY.SetValue(this, error);
                NONCE_PROPERTY.SetValue(this, nonce);
                RETRY_STATE_PROPERTY.SetValue(this, retryState);
                STATE_PROPERTY.SetValue(this, state);
                ACCEPTED_PROPERTY.SetValue(this, accepted);
                RECEIPT_PROPERTY.SetValue(this, receipt);
                TOKEN_ID_PROPERTY.SetValue(this, tokenId);
                CREATED_AT_PROPERTY.SetValue(this, createdAt);
                UPDATED_AT_PROPERTY.SetValue(this, updatedAt);
            }
        }
    }
}
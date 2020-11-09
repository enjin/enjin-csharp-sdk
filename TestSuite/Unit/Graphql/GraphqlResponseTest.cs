using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TestSuite.Utils;

namespace TestSuite
{
    [TestFixture]
    public class GraphqlResponseTest
    {
        private static readonly DummyObject DEFAULT_RESULT = DummyObject.CreateDefault();
        private static readonly List<DummyObject> DEFAULT_ITEMS = new List<DummyObject>();
        private static readonly List<GraphqlError> DEFAULT_ERRORS = new List<GraphqlError>();
        private static readonly PaginationCursor DEFAULT_CURSOR = new PaginationCursor();

        [OneTimeSetUp]
        public static void BeforeAll()
        {
            DEFAULT_ITEMS.Add(new DummyObject(1));
            DEFAULT_ITEMS.Add(new DummyObject(2));
            DEFAULT_ITEMS.Add(new DummyObject(3));
            DEFAULT_ERRORS.Add(new GraphqlError());
            DEFAULT_ERRORS.Add(new GraphqlError());
            DEFAULT_ERRORS.Add(new GraphqlError());
        }

        [Test]
        public void HasErrors_ErrorsArePresent_ReturnsTrue()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.Parse(@"null"));
            var response = new GraphqlResponse<DummyObject>(data, DEFAULT_ERRORS);

            // Act
            var actual = response.HasErrors;

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void HasErrors_ErrorsAreNotPresent_ReturnsFalse()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.FromObject(DEFAULT_RESULT));
            var response = new GraphqlResponse<DummyObject>(data, null);

            // Act
            var actual = response.HasErrors;

            // Assert
            Assert.IsFalse(actual);
        }
        
        [Test]
        public void HasErrors_ErrorsAreEmpty_ReturnsFalse()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.Parse(@"null"));
            var response = new GraphqlResponse<DummyObject>(data, new List<GraphqlError>());

            // Act
            var actual = response.HasErrors;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void IsEmpty_ReturnsTrue()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.Parse(@"null"));
            var response = new GraphqlResponse<DummyObject>(data, null);

            // Act
            var actual = response.IsEmpty;

            // Assert
            Assert.IsTrue(actual);
        }
        
        [Test]
        public void IsEmpty_ReturnsFalse()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.FromObject(DEFAULT_RESULT));
            var response = new GraphqlResponse<DummyObject>(data, null);

            // Act
            var actual = response.IsEmpty;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPaginated_ReturnsTrue()
        {
            // Arrange
            var resultString = $"{{\"items\": {JToken.FromObject(DEFAULT_ITEMS)}, \"cursor\": {JToken.FromObject(DEFAULT_CURSOR)}}}";
            var data = new GraphqlData<List<DummyObject>>(JToken.Parse(resultString));
            var response = new GraphqlResponse<List<DummyObject>>(data, null);

            // Act
            var actual = response.IsPaginated;

            // Assert
            Assert.IsTrue(actual);
        }
        
        [Test]
        public void IsPaginated_CursorNotIn_ReturnsFalse()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.FromObject(DEFAULT_RESULT));
            var response = new GraphqlResponse<DummyObject>(data, null);

            // Act
            var actual = response.IsPaginated;

            // Assert
            Assert.IsFalse(actual);
        }
        
        [Test]
        public void IsSuccess_NoErrorsAndIsNotEmpty_ReturnsTrue()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.FromObject(DEFAULT_RESULT));
            var response = new GraphqlResponse<DummyObject>(data, null);

            // Act
            var actual = response.IsSuccess;

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsSuccess_HasErrorsAndIsEmpty_ReturnsFalse()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.Parse(@"null"));
            var response = new GraphqlResponse<DummyObject>(data, DEFAULT_ERRORS);

            // Act
            var actual = response.IsSuccess;

            // Assert
            Assert.IsFalse(actual);
        }
        
        [Test]
        public void IsSuccess_HasErrorsAndIsNotEmpty_ReturnsFalse()
        {
            // Arrange
            var data = new GraphqlData<DummyObject>(JToken.FromObject(DEFAULT_RESULT));
            var response = new GraphqlResponse<DummyObject>(data, DEFAULT_ERRORS);

            // Act
            var actual = response.IsSuccess;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ToString_DoesNotHaveErrors_ReturnsStringContainingResult()
        {
            // Arrange
            var expected = $"Result: {DEFAULT_RESULT}";
            var data = new GraphqlData<DummyObject>(JToken.FromObject(DEFAULT_RESULT));
            var response = new GraphqlResponse<DummyObject>(data, null);

            // Act
            var actual = response.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_DoesHaveErrors_ReturnsStringContainingErrors()
        {
            // Arrange
            var expected = $"Errors: {DEFAULT_ERRORS}";
            var data = new GraphqlData<DummyObject>(JToken.Parse(@"null"));
            var response = new GraphqlResponse<DummyObject>(data, DEFAULT_ERRORS);

            // Act
            var actual = response.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
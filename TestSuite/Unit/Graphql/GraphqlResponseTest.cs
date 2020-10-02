using Enjin.SDK.Graphql;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class GraphqlResponseTest
    {
        private static readonly GraphqlData<object> DEFAULT_DATA =
            new GraphqlData<object>(JObject.FromObject(new object()));

        private static readonly JToken DEFAULT_ERRORS = new JArray();

        [Test]
        public void Constructor_NonNullDataNonNullErrors_DoesNotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new GraphqlResponse<object>(DEFAULT_DATA, DEFAULT_ERRORS));
        }

        [Test]
        public void Constructor_NonNullDataNullErrors_DoesNotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new GraphqlResponse<object>(DEFAULT_DATA, null));
        }

        [Test]
        public void Constructor_NullDataNonNullErrors_DoesNotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new GraphqlResponse<object>(null, DEFAULT_ERRORS));
        }

        [Test]
        public void Constructor_NullDataNullErrors_DoesNotThrowException()
        {
            // Assert
            Assert.DoesNotThrow(() => new GraphqlResponse<object>(null, null));
        }

        [Test]
        public void Result_NonNullResultInData_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_DATA.Result;
            var response = new GraphqlResponse<object>(DEFAULT_DATA, DEFAULT_ERRORS);

            // Act
            var actual = response.Result;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Result_NullData_GetsValue()
        {
            // Arrange
            var response = new GraphqlResponse<object>(null, DEFAULT_ERRORS);

            // Act
            var actual = response.Result;

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Errors_NonNullErrors_GetsValue()
        {
            // Arrange
            var expected = DEFAULT_ERRORS;
            var response = new GraphqlResponse<object>(DEFAULT_DATA, expected);

            // Act
            var actual = response.Errors;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Errors_NullErrors_GetsValue()
        {
            // Arrange
            var response = new GraphqlResponse<object>(DEFAULT_DATA, null);

            // Act
            var actual = response.Errors;

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void HasErrors_ErrorsArePresent_ReturnsTrue()
        {
            // Arrange
            var response = new GraphqlResponse<object>(DEFAULT_DATA, DEFAULT_ERRORS);

            // Act
            var actual = response.HasErrors();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void HasErrors_ErrorsAreNotPresent_ReturnsFalse()
        {
            // Arrange
            var response = new GraphqlResponse<object>(DEFAULT_DATA, null);

            // Act
            var actual = response.HasErrors();

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ToString_DoesNotHaveErrors_ReturnsStringContainingResult()
        {
            // Arrange
            var expected = $"Result: {DEFAULT_DATA.Result}";
            var response = new GraphqlResponse<object>(DEFAULT_DATA, null);

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
            var response = new GraphqlResponse<object>(DEFAULT_DATA, DEFAULT_ERRORS);

            // Act
            var actual = response.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
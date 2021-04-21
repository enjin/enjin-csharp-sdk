using System;
using Enjin.SDK.Utils;
using Moq;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class LoggerProviderTest
    {
        private const string DefaultMessage = "Test Message";
        
        private LoggerProvider ClassUnderTest { get; set; }
        
        private ILogger MockLogger { get; set; }

        private static Exception CreateDefaultException()
        {
            return new Exception("Default Exception");
        }

        [SetUp]
        public void BeforeEach()
        {
            MockLogger = Mock.Of<ILogger>();
            ClassUnderTest = new LoggerProvider(MockLogger);
        }
        
        [Test]
        public void Log_GivenMessage_LogsDataAtDefaultLevel()
        {
            // Arrange - Data
            const string message = DefaultMessage;
            LogLevel level = ClassUnderTest.DefaultLevel;

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(true)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message))
                .Verifiable();

            // Act
            ClassUnderTest.Log(message);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message), Times.Once);
        }
        
        [Test]
        public void Debug_GivenMessage_LogsDataAtDebugLevel()
        {
            // Arrange - Data
            const string message = DefaultMessage;
            LogLevel level = ClassUnderTest.DebugLevel;

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(true)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message))
                .Verifiable();

            // Act
            ClassUnderTest.Debug(message);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message), Times.Once);
        }
        
        [Test]
        public void Log_GivenMessageWithLoggableLevel_LogsDataAtLogLevel([Values] LogLevel level)
        {
            // Arrange - Data
            const string message = DefaultMessage;

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(true)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message))
                .Verifiable();

            // Act
            ClassUnderTest.Log(level, message);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message), Times.Once);
        }
        
        [Test]
        public void Log_GivenMessageWithNonLoggableLevel_DoesNotLogData([Values] LogLevel level)
        {
            // Arrange - Data
            const string message = DefaultMessage;

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(false)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message))
                .Verifiable();

            // Act
            ClassUnderTest.Log(level, message);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message), Times.Never);
        }

        [Test]
        public void Log_GivenMessageAndException_LogsDataAtDefaultLevel()
        {
            // Arrange - Data
            const string message = DefaultMessage;
            Exception exception = CreateDefaultException();
            LogLevel level = ClassUnderTest.DefaultLevel;

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(true)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message, exception))
                .Verifiable();

            // Act
            ClassUnderTest.Log(message, exception);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message, exception), Times.Once);
        }
        
        [Test]
        public void Debug_GivenMessageAndException_LogsDataAtDebugLevel()
        {
            // Arrange - Data
            const string message = DefaultMessage;
            Exception exception = CreateDefaultException();
            LogLevel level = ClassUnderTest.DebugLevel;

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(true)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message, exception))
                .Verifiable();

            // Act
            ClassUnderTest.Debug(message, exception);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message, exception), Times.Once);
        }
        
        [Test]
        public void Log_GivenMessageAndExceptionWithLoggableLevel_LogsDataAtLogLevel([Values] LogLevel level)
        {
            // Arrange - Data
            const string message = DefaultMessage;
            Exception exception = CreateDefaultException();

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(true)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message, exception))
                .Verifiable();

            // Act
            ClassUnderTest.Log(level, message, exception);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message, exception), Times.Once);
        }
        
        [Test]
        public void Log_GivenMessageAndExceptionWithNonLoggableLevel_DoesNotLogData([Values] LogLevel level)
        {
            // Arrange - Data
            const string message = DefaultMessage;
            Exception exception = CreateDefaultException();

            // Arrange - Expectations
            Mock.Get(MockLogger)
                .Setup(mock => mock.IsLoggable(level))
                .Returns(false)
                .Verifiable();
            Mock.Get(MockLogger)
                .Setup(mock => mock.Log(level, message, exception))
                .Verifiable();

            // Act
            ClassUnderTest.Log(level, message, exception);

            // Verify
            Mock.Get(MockLogger)
                .Verify(mock => mock.IsLoggable(level), Times.AtLeastOnce);
            Mock.Get(MockLogger)
                .Verify(mock => mock.Log(level, message, exception), Times.Never);
        }
    }
}
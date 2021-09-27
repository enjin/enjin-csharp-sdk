/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
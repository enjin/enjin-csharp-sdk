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

using System.Collections.Generic;
using Enjin.SDK.Events;
using Enjin.SDK.Models;
using Moq;
using NUnit.Framework;
using PusherClient;
using TestSuite.Utils;

namespace TestSuite
{
    [TestFixture]
    public class PusherEventListenerTest
    {
        private PusherEventService FakeEventService { get; set; }
        
        private PusherEventListener ClassUnderTest { get; set; }
        
        [SetUp]
        public void BeforeEach()
        {
            FakeEventService = new PusherEventService(PlatformUtils.CreateFakePlatform("test"));
            ClassUnderTest = new PusherEventListener(FakeEventService);
        }

        [Test]
        public void OnEvent_UnknownEventType_DoesNothing()
        {
            // Arrange - Data
            const string eventName = "";
            const string channelName = "";
            const string data = "";
            var fakePusherEvent = CreateFakePusherEvent(eventName, channelName, data, "");
            var mockEventListener = Mock.Of<IEventListener>();
            FakeEventService.RegisterListener(mockEventListener);

            // Arrange - Expectations
            Mock.Get(mockEventListener)
                .Setup(mock => mock.NotificationReceived(It.IsAny<NotificationEvent>()));

            // Act
            ClassUnderTest.OnEvent(fakePusherEvent);

            // Verify
            Mock.Get(mockEventListener)
                .Verify(mock => mock.NotificationReceived(It.IsAny<NotificationEvent>()), Times.Never);
        }

        [TestCase("EnjinCloud\\Events\\ProjectCreated")]
        [TestCase("EnjinCloud\\Events\\PlayerLinked")]
        [TestCase("EnjinCloud\\Events\\AssetTransferred")]
        [TestCase("EnjinCloud\\Events\\TransactionExecuted")]
        public void OnEvent_ValidEventForRegisteredListener_DoesCallRegisteredListener(string eventName)
        {
            // Arrange - Data
            const string channelName = "";
            const string data = "";
            var fakePusherEvent = CreateFakePusherEvent(eventName, channelName, data, "");
            var mockEventListener = Mock.Of<IEventListener>();
            FakeEventService.RegisterListener(mockEventListener);
            
            // Arrange - Expectations
            Mock.Get(mockEventListener)
                .Setup(mock => mock.NotificationReceived(It.IsAny<NotificationEvent>()));

            // Act
            ClassUnderTest.OnEvent(fakePusherEvent);

            // Verify
            Mock.Get(mockEventListener)
                .Verify(mock => mock.NotificationReceived(It.IsAny<NotificationEvent>()), Times.Once);
        }
        
        [TestCase("EnjinCloud\\Events\\ProjectCreated")]
        public void OnEvent_InvalidEventForRegisteredListener_DoesNotCallRegisteredListener(string eventName)
        {
            // Arrange - Data
            const string channelName = "";
            const string data = "";
            var fakePusherEvent = CreateFakePusherEvent(eventName, channelName, data, "");
            var mockEventListener = Mock.Of<IEventListener>();
            FakeEventService.RegisterListenerExcludingTypes(mockEventListener, EventType.PROJECT_CREATED);
            
            // Arrange - Expectations
            Mock.Get(mockEventListener)
                .Setup(mock => mock.NotificationReceived(It.IsAny<NotificationEvent>()));

            // Act
            ClassUnderTest.OnEvent(fakePusherEvent);

            // Verify
            Mock.Get(mockEventListener)
                .Verify(mock => mock.NotificationReceived(It.IsAny<NotificationEvent>()), Times.Never);
        }

        private static PusherEvent CreateFakePusherEvent(string eventName, string channelName, string data, string raw)
        {
            return new PusherEvent(new Dictionary<string, object>
            {
                {"event", eventName},
                {"channel", channelName},
                {"data", data},
            }, raw);
        }
    }
}
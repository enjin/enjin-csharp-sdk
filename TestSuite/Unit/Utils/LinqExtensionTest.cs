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
using System.Runtime.CompilerServices;
using Enjin.SDK.Utils;
using Moq;
using NUnit.Framework;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace TestSuite
{
    [TestFixture]
    public class LinqExtensionTest
    {
        [Test]
        public void Do_DoActionOnAllElements()
        {
            // Arrange - Data
            var mock1 = Mock.Of<ITestClass>(MockBehavior.Strict);
            var mock2 = Mock.Of<ITestClass>(MockBehavior.Strict);
            var mock3 = Mock.Of<ITestClass>(MockBehavior.Strict);
            var list = new List<ITestClass> {mock1, mock2, mock3};

            // Arrange - Expectations
            Mock.Get(mock1)
                .Setup(mock => mock.MethodToCall());
            Mock.Get(mock2)
                .Setup(mock => mock.MethodToCall());
            Mock.Get(mock3)
                .Setup(mock => mock.MethodToCall());
            
            // Act
            list.Do(o => o.MethodToCall());
            
            // Verify
            Mock.Get(mock1)
                .Verify(mock => mock.MethodToCall(), Times.Once);
            Mock.Get(mock2)
                .Verify(mock => mock.MethodToCall(), Times.Once);
            Mock.Get(mock3)
                .Verify(mock => mock.MethodToCall(), Times.Once);
        }

        internal interface ITestClass
        {
            void MethodToCall();
        }
    }
}
﻿using System.Collections.Generic;
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
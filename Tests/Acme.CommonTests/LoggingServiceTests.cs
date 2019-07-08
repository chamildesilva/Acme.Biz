using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common.Tests
{
    [TestClass()]
    public class LoggingServiceTests
    {
        [TestMethod()]
        public void LogAction_Success()
        {
            // Arrange
            
            var expected = "Action: Test Action";

            // Act
            //Static class cannot be iniliazed so class name is directly used
            var actual = LoggingService.LogAction("Test Action");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
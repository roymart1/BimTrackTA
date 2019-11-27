
using NLog;
using NUnit.Framework;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class LoggerTests
    {
        private Logger logger;
        
        public LoggerTests()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        [Test]
        public void Test_Logger_Strategy()
        {    
//            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Debug("Hello World");

            var log2 = NLog.LogManager.GetLogger("MPR");
            log2.Debug("Debugging");
            log2.Debug("WhatEVER---------------");
            this.test_my_logger();
        }


        private void test_my_logger()
        {
//            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Debug("Yes --- In the Other");

        }
    }
}
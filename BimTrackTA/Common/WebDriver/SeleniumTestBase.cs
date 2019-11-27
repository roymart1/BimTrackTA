using System;
using System.Diagnostics;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace SeleniumTest.Common
{
    public class SeleniumTestBase : GeneralTestBase
    {
        public SeleniumTestBase()
        {
            ChromeOptions cOptions = new ChromeOptions();
            cOptions.AddExcludedArgument("enable-automation");
            cOptions.AddAdditionalCapability("useAutomationExtension", false);
            
            cOptions.AddUserProfilePreference("credentials_enable_service", false);
            cOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            
            CTX.driver = new ChromeDriver("/Users/martin-pierreroy/Devl/tools/", cOptions);
            CTX.ef_driver = new EventFiringWebDriver(CTX.driver);
            
            CTX.ef_driver.ExceptionThrown +=
                new EventHandler<WebDriverExceptionEventArgs>(firingDriver_ExceptionThrown);

            CTX.ef_driver.ElementClicked +=
                new EventHandler<WebElementEventArgs>(firingDriver_ElementClicked);

            CTX.ef_driver.FindElementCompleted +=
                new EventHandler<FindElementEventArgs>(firingDriver_FindElementCompleted);

            CTX.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CTX.driver = CTX.ef_driver;
        }
        
        private static void firingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.Out.WriteLine("firingDriver_ExceptionThrown");
            Console.Out.WriteLine(e.ThrownException.Message);
        }

        private static void firingDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.Out.WriteLine("firingDriver_ElementClicked");
            Console.Out.WriteLine(e.Element);
        }

        private static void firingDriver_FindElementCompleted(object sender, FindElementEventArgs e)
        {
            Console.Out.WriteLine("firingDriver_FindElementCompleted");
            Console.Out.WriteLine(e.FindMethod);
        }
    }
}
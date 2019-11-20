using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace SeleniumTest.Common.WebDriver
{
    public class BTEventListener
    {
        
        public void OnNavigating(WebDriverNavigationEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnNavigating");
        }

        public void OnNavigated(WebDriverNavigationEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnNavigated");
        }

        public void OnNavigatingBack(WebDriverNavigationEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnNavigatingBack");
        }

        public void OnNavigatedBack(WebDriverNavigationEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnNavigatedBack");
        }

        public void OnNavigatingForward(WebDriverNavigationEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnNavigatingForward");
        }

        public void OnNavigatedForward(WebDriverNavigationEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnNavigatedForward");
        }

        public void OnElementClicking(WebElementEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnElementClicking");
        }

        public void OnElementClicked(WebElementEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnElementClicked");
        }

        public void OnElementValueChanging(WebElementValueEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnElementValueChanging");
        }

        public void OnElementValueChanged(WebElementValueEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnElementValueChanged");
        }

        public void OnFindingElement(FindElementEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnFindingElement");
        }

        public void OnFindElementCompleted(FindElementEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnFindElementCompleted");
        }

        public void OnScriptExecuting(WebDriverScriptEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnScriptExecuting");
        }

        public void OnScriptExecuted(WebDriverScriptEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnScriptExecuted");
        }

        public void OnException(WebDriverExceptionEventArgs e)
        {
            Console.Out.WriteLine("EventFiringWebDriver --> OnException");
        }
    }
}
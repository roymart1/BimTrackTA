using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumTest.Common.WebDriver;

namespace SeleniumTest.Common
{
    public class CTX
    {
        // used to contextualize the view component to the appropriate user options
        public enum enumUserType {administrator, guest};
        
        public static IWebDriver driver;
        public static EventFiringWebDriver ef_driver;

        
        private static string keyChainID;
        public static KeyChain keyChain;
        
        public static enumUserType userType = enumUserType.administrator;

        public static BTEventListener event_listener = new BTEventListener();
        

        public static KeyChain SetKeyChainId(string id = "QA")
        {
            CTX.keyChainID = id;
            CTX.keyChain = KeyChain.GetInstance(CTX.keyChainID);
            return CTX.keyChain;
        }


    }
}
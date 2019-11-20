using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SeleniumTest.Common
{
    public class KeyChain
    {
        /////////////////////////////////////////////////////////??/
        // START NAMED BASED SINGLETON PATTERN
        private static Dictionary<string, KeyChain> listKeyChains = new Dictionary<string, KeyChain>();
        
        public static KeyChain GetInstance(string keychainId)
        {
            KeyChain instKeyChain;
            
            if (listKeyChains.TryGetValue(keychainId, out instKeyChain))
            {
                return instKeyChain;
            }
            else
            {
                instKeyChain = new KeyChain(keychainId);
                listKeyChains.Add(keychainId, instKeyChain);
            }

            return instKeyChain;
        }
        
        /// <summary>
        /// Private constructor to be instantiated only be the GetInstance singleton constructor 
        /// </summary>
        private KeyChain(string keychainID)
        {
            LoadTestData(keychainID);
            // TODO: Add pull test data from database
        }
        // END SINGLETON PATTERN
        /////////////////////////////////////////////////////////??/

        public string LoginUsername;
        public string LoginPassword;
        public string ApiKey;
        public string UrlBimtrack;
        public string HubName;
        public string DefaultProject;
        public string email_username = "bimoneauto";
        public string email_password = "B1m0n3 Rules 99!";
        
        
        /// <summary>
        /// Load the keychain data based on a string ID that act as unique identifier
        /// </summary>
        /// <param name="keyId">the identifier that act as unique identifier to the keychain</param>
        private void LoadTestData(string keyId)
        {
            if (keyId == "QA")
            {
                LoginUsername = "zenteliatest@gmail.com";
                LoginPassword = "Z3nt3l1499!";
                ApiKey = "df92c0de76709a639c9b047b163279535ccf670d89b3f81e642ef69e6511abd8";
                UrlBimtrack = "https://qa.bimtrack.co/";
                HubName = "ZenyTest";
                DefaultProject = "ZenProjectQA";
                email_username = "bimoneauto";
                email_password = "B1m0n3 Rules 99!";
            }
            else // Assume demo for now
            {
                LoginUsername = "zenteliatest@gmail.com";
                LoginPassword = "Z3nt3l1499!";
                ApiKey = "3d77a3ae21baa8f69021904db31b25d8103c98beac5df608a8fb96e2f10f6f62";
                UrlBimtrack = "https://qa.bimtrack.co/";
                HubName = "ZenyTestB";
                DefaultProject = "ZENPROJECT001";
                email_username = "bimoneauto";
                email_password = "B1m0n3 Rules 99!";
            }
        }


    }
}
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
        ////////////////////////////////////////////////////////////

        // Main portal url and credentials
        public string UrlBimTrack;
        public string LoginUsername;
        public string LoginPassword;
        // API related
        public string ApiKey;
        public string ApiUrl;
            
        public string HubName;
        public string DefaultProject;

        // Email processing credentials
        public string EmailUsername;
        public string EmailPassword;
        
        
        /// <summary>
        /// Load the keychain data based on a string ID that act as unique identifier
        /// </summary>
        /// <param name="keyId">the identifier that act as unique identifier to the keychain</param>
        private void LoadTestData(string keyId)
        {
            if (keyId == "QA")
            {
                // BimTrack portal
                UrlBimTrack = "https://qa.bimtrack.co/";
                LoginUsername = "zenteliatest@gmail.com";
                LoginPassword = "Z3nt3l1499!";
                HubName = "ZenyTest";
                DefaultProject = "ZenProjectQA";
                // API
                ApiKey = "df92c0de76709a639c9b047b163279535ccf670d89b3f81e642ef69e6511abd8";
                ApiUrl = "https://apiqa.bimtrack.co";
                // Email processing
                EmailUsername = "bimoneauto";
                EmailPassword = "B1m0n3 Rules 99!";
            }
            else // Assume demo for now
            {
                // BimTrack portal
                UrlBimTrack = "https://qa.bimtrack.co/";
                LoginUsername = "zenteliatest@gmail.com";
                LoginPassword = "Z3nt3l1499!";
                HubName = "ZenyTestB";
                DefaultProject = "ZENPROJECT001";
                // API
                ApiKey = "3d77a3ae21baa8f69021904db31b25d8103c98beac5df608a8fb96e2f10f6f62";
                ApiUrl = "https://api.bimtrackapp.co";
                // Email processing
                EmailUsername = "bimoneauto";
                EmailPassword = "B1m0n3 Rules 99!";
            }
        }


    }
}
using RestSharp;
using SeleniumTest.Common;

namespace BimTrackTA.API
{
    public class APIBase
    {
        protected RestClient client;  
            
        
        public APIBase()
        {
            string szKey = CTX.keyChain.ApiKey;
            client = new RestClient(CTX.keyChain.ApiUrl)
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            client.AddDefaultHeader("Authorization", $"Bearer {szKey}");
        }
    }
}
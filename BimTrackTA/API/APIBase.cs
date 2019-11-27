using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.Common;
using SeleniumTest.Common.Exceptions;

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
        
        
        protected void ProcessResponseError(IRestResponse response)
        {
            if (response.IsSuccessful != true)
            {
                JObject json = JObject.Parse(response.Content);
                JToken message = json["Message"];
                throw new BTException("Exception - Error Message: " + message.ToString());
            }
        }
    }
}
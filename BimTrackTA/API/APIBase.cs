using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.BusinessObjects;
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

        protected IRestResponse Perform_Delete(string connectionStr)
        {
            var request = new RestRequest(connectionStr, Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response;
        }

        protected List<T> Perform_Get<T>(string connectionStr)
        {
            RestRequest request = new RestRequest(connectionStr, Method.GET);
            IRestResponse response = client.Execute(request);
            List<T> listTemplates = JsonConvert.DeserializeObject<List<T>>(response.Content);
            return listTemplates;
        }
        

    }
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;

namespace BimTrackTA.API
{
    public class HubAPI : APIBase
    {
        public List<Hub> GetHubList()
        {
//            RestRequest request = new RestRequest("v2/hubs/", Method.GET);
//            IRestResponse response = client.Execute(request);
//            List<Hub> resPack = JsonConvert.DeserializeObject<List<Hub>>(response.Content);
//            return resPack;
            
            string connStr = "v2/hubs/";
            return Perform_Get<Hub>(connStr);
        }
        
        public Hub GetHub(int hubId)
        {
            RestRequest request = new RestRequest("v2/hubs/" + hubId, Method.GET);
            IRestResponse response = client.Execute(request);
            Hub retHub = JsonConvert.DeserializeObject<Hub>(response.Content);
            return retHub;
        }

        public List<ProjectTemplate> GetHubProjectTemplates(int hubId)
        {
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projecttemplates", Method.GET);
            IRestResponse response = client.Execute(request);
            List<ProjectTemplate> listTemplates = JsonConvert.DeserializeObject<List<ProjectTemplate>>(response.Content);
            return listTemplates;
        }

        
        public List<ProjectTemplate> GetHubProjectTemplates2(int hubId)
        {
            string connStr = "v2/hubs/" + hubId + "/projecttemplates";
            return Perform_Get<ProjectTemplate>(connStr);
        }
        
        
        
        


    }


}


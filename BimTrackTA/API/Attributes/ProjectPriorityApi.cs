using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectPriorityApi : ApiBase
    {
        public List<Priority> GetHubProjectPriorityList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities";
            return Perform_Get<List<Priority>>(connStr);
        }

        public bool CreateHubProjectPriority(int hubId, int projectId, string name)
        {
            string jsonToSend = "{'Name': '" + name + "'}";
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }

        public bool DeleteHubProjectPriority(int hubId, int projectId, int priorityId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities/" + priorityId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectPriority(int hubId, int projectId, int priorityId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/priorities/" + priorityId;
            
            IRestResponse response = Perform_Update(connStr, jsonToSend);
            return response.IsSuccessful;
        }
        
    }
}
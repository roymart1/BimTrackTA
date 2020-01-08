using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectStatusApi : ApiBase
    {
        public List<Status> GetHubProjectStatusList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status";
            return Perform_Get<List<Status>>(connStr);
        }

        public bool CreateHubProjectStatus(int hubId, int projectId, string name)
        {
            string jsonToSend = "{'Name': '" + name + "'}";
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }

        public bool DeleteHubProjectStatus(int hubId, int projectId, int statusId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status/" + statusId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectStatus(int hubId, int projectId, int statusId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/status/" + statusId;
            
            IRestResponse response = Perform_Update(connStr, jsonToSend);
            return response.IsSuccessful;
        }
        
    }
}
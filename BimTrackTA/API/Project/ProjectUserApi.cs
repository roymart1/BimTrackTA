using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectUserApi : ApiBase
    {
        
        
        
        public List<ProjectUser> GetHubProjectUsers(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users";
            return Perform_Get<List<ProjectUser>>(connStr);
        }

        public bool CreateHubProjectUser(int hubId, int projectId, int userId)
        {
            string jsonToSend = "{'UserId': 0, 'Role': 'Reader', 'ProjectTeams': [0]}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            return Perform_Delete(connStr);
        }

        public bool UpdateHubProjectUser(int hubId, int projectId, int userId, string key, object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}
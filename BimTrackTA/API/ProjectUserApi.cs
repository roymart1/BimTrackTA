
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectUserApi : APIBase
    {
        
        
        
        public List<ProjectUser> GetHubProjectUsers(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users";
            return Perform_Get<List<ProjectUser>>(connStr);
        }

        public bool CreateHubProjectUser(int hubId, int projectId, int userId)
        {
            string jsonToSend = "{'UserId': 0, 'Role': 'Reader', 'ProjectTeams': [0]}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/user";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful != true;
        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            return Perform_Delete(connStr);
        }

    }
}
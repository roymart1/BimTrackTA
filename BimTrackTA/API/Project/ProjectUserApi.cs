using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectUserApi : ApiBase
    {
        
        
        
        public List<User> GetHubProjectUsers(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users";
            return Perform_Get<List<User>>(connStr);
        }

        public bool CreateHubProjectUser(int hubId, int projectId, ProjectUser user)
        {
            string jsonPayload = JsonConvert.SerializeObject(user);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            return Perform_Delete(connStr);
        }

        public bool UpdateHubProjectUser(int hubId, int projectId, int userId, ProjectUser user)
        {
            string jsonPayload = JsonConvert.SerializeObject(user);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            IRestResponse response = Perform_Update(connStr, jsonPayload);

            return response.IsSuccessful;
        }
    }
}
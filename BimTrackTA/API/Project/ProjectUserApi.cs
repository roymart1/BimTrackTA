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

        public int CreateHubProjectUser(int hubId, int projectId, ProjectUser user)
        {
            // Required fields for ProjectUser object are: 
            //     - UserId (int)
            //     - Role ('Editor' or 'Reader')
            //
            // CTRL+Click on ProjectUser for further details about the object's attributes
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users";
            return Perform_Create(connStr, user);
        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            return Perform_Delete(connStr);
        }

        public bool UpdateHubProjectUser(int hubId, int projectId, int userId, ProjectUser user)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            IRestResponse response = Perform_Update(connStr, user);

            return response.IsSuccessful;
        }
    }
}
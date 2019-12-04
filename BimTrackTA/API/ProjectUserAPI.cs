
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectUserAPI : APIBase
    {
        
        
        
        public List<ProjectUser> GetHubProjectUsers(int hubId, int projectId)
        {
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects/" + projectId + "/users", Method.GET);
            IRestResponse response = client.Execute(request);
            List<ProjectUser> projectUserList = JsonConvert.DeserializeObject<List<ProjectUser>>(response.Content);
           
            return projectUserList;
        }

        public bool CreateHubProjectUser(int hubId, int projectId, int userId)
        {


            string jsonToSend = "{'UserId': 0, 'Role': 'Reader', 'ProjectTeams': [0]}";
           
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects/" + projectId + "/user", Method.POST);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            this.ProcessResponseError(response);
            return true;

        }
        
               
        public IRestResponse DeleteHubProjectUser(int hubId, int projectId, int userId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/users/" + userId;
            return Perform_Delete(connStr);
        }

    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectTeamAPI : APIBase
    {
        
        public List<Team> GetHubProjectTeams(int hubId, int projectId)
        {
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects/" + projectId + "/teams", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Team> projectTeams = JsonConvert.DeserializeObject<List<Team>>(response.Content);
           
            return projectTeams;
        }
        
        
        public bool CreateHubProjectTeam(int hubId, int projectId, string teamName)
        {
            string jsonToSend = "{'Name': '"+ teamName +"'}";
           
            RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects/" + projectId + "/teams", Method.POST);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            this.ProcessResponseError(response);
            return true;
        }
        
        public IRestResponse DeleteHubProjectTeam(int hubId, int projectId, int teamId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams/" + teamId;
            return Perform_Delete(connStr);
        }
        
               
        public List<User> GetHubProjectTeamUsers(int hubId, int projectId, int teamId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/teams/users?teamId=" + teamId;
            RestRequest request = new RestRequest(connStr, Method.GET);
            IRestResponse response = client.Execute(request);
            List<User> listUser = JsonConvert.DeserializeObject<List<User>>(response.Content);
           
            return listUser;
        }
        
    }
}
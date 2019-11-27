using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class ProjectAPI : APIBase
    {
       public List<Project>  GetHubProjectList(int hubId)
       {
           RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects", Method.GET);
           IRestResponse response = client.Execute(request);
           List<Project> projectList = JsonConvert.DeserializeObject<List<Project>>(response.Content);
           
           return projectList;
       }

       public void CreateNewProject(int hubId, int templateId, string prjName)
       {
           string jsonToSend = "{'ProjectTemplateId':" + templateId + ",'Name': '" + prjName + "'}";
           
           RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects", Method.POST);
           request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
           request.RequestFormat = DataFormat.Json;
           var response = client.Execute(request);
           this.ProcessResponseError(response);
       }

       public List<ProjectUser> GetHubProjectUsers(int hubId, int projectId)
       {
           RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects/" + projectId + "/users", Method.GET);
           IRestResponse response = client.Execute(request);
           List<ProjectUser> projectUserList = JsonConvert.DeserializeObject<List<ProjectUser>>(response.Content);
           
           return projectUserList;
       }

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
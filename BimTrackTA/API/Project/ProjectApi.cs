using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectApi : ApiBase
    {
       public List<Project>  GetHubProjectList(int hubId)
       {
           string connStr = "v2/hubs/" + hubId + "/projects";
           return Perform_Get<List<Project>>(connStr);
       }

       public bool CreateHubProject(int hubId, Project project)
       {
           // Required fields for Project object are: 
           //     - Name (string)
           //
           // CTRL+Click on Project for further details about the object's attributes
           string jsonPayload = JsonConvert.SerializeObject(project);
           string connStr = "v2/hubs/" + hubId + "/projects";
           IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
           return response.IsSuccessful;
       }

       public Project GetHubProjectDetails(int hubId, int projectId)
       {
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           return Perform_Get<Project>(connStr);
       }

       public bool UpdateHubProject(int hubId, int projectId, Project project)
       {
           string jsonPayload = JsonConvert.SerializeObject(project);
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           IRestResponse response = Perform_Update(connStr, jsonPayload);

           return response.IsSuccessful;
       }
    }
}
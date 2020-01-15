using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class ProjectApi : ApiBase
    {
       public List<Project> GetHubProjectList(int hubId)
       {
           string connStr = "v2/hubs/" + hubId + "/projects";
           return Perform_Get<List<Project>>(connStr);
       }

       public int CreateHubProject(int hubId, Project project)
       {
           // Required fields for Project object are: 
           //     - Name (string)
           //
           // CTRL+Click on Project for further details about the object's attributes
           string connStr = "v2/hubs/" + hubId + "/projects";
           return Perform_Create(connStr, project);
       }

       public Project GetHubProjectDetails(int hubId, int projectId)
       {
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           return Perform_Get<Project>(connStr);
       }

       public bool UpdateHubProject(int hubId, int projectId, Project project)
       {
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           IRestResponse response = Perform_Update(connStr, project);

           return response.IsSuccessful;
       }
    }
}
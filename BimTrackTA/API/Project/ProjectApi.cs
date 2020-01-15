using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

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
           // Validate that the object is fine
           ValidateOperation(project);
           
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
       
       private void ValidateOperation(Project project)
       {
           if (project == null) throw new ArgumentNullException(nameof(project));
           if (project.Name == null)
           {
               throw new CustomObjectAttributeException("a name", "project");
           }
       }
    }
}
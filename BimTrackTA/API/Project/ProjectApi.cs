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
           string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE;
           return Perform_Get<List<Project>>(connStr);
       }

       public int CreateHubProject(int hubId, Project project)
       {
           // N.B. : It is not possible to delete a project from the API. Thus, you either need to use the
           //        GUI framework to delete it, or use the browser. I suggest you do that quite often so that
           //        you don't end up with 20 thousands projects of the same name.
           
           // Validate that the object is fine
           ValidateOperation(project);
           
           // Required fields for Project object are: 
           //     - Name (string)
           //
           // CTRL+Click on Project for further details about the object's attributes
           string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE;
           return Perform_Create(connStr, project);
       }

       public Project GetHubProjectDetails(int hubId, int projectId)
       {
           string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId;
           return Perform_Get<Project>(connStr);
       }

       public bool UpdateHubProject(int hubId, int projectId, Project project)
       {
           string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId;
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
using System.Collections.Generic;
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

       public bool CreateHubProject(int hubId, string prjName, int projectTemplateId=-1)
       {
           string jsonToSend = "{'Name': '" + prjName + "'}";
           if (projectTemplateId != -1)
           {
               jsonToSend = "{'ProjectTemplateId':" + projectTemplateId + ", 'Name': '" + prjName + "'}";
           }
           string connStr = "v2/hubs/" + hubId + "/projects";
           IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
           return response.IsSuccessful;
       }

       public Project GetHubProjectDetails(int hubId, int projectId)
       {
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           return Perform_Get<Project>(connStr);
       }

       public bool UpdateHubProject(int hubId, int projectId, string key, object value)
       {
           string jsonToSend = Create_UpdateJsonString(key, value);
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           IRestResponse response = Perform_Update(connStr, jsonToSend);

           return response.IsSuccessful;
       }
    }
}
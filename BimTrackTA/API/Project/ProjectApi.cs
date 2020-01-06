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

       public bool CreateHubProject(int hubId, int templateId, string prjName)
       {
           string jsonToSend = "{'ProjectTemplateId':" + templateId + ",'Name': '" + prjName + "'}";
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
           string jsonToSend = "{'" + key + "': '" + value + "'}";
           string connStr = "v2/hubs/" + hubId + "/projects/" + projectId;
           IRestResponse response = Perform_Update(connStr, jsonToSend);

           return response.IsSuccessful;
       }
    }
}
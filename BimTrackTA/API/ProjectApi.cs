using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

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

    }
}
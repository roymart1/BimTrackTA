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
           string connStr = "v2/hubs/" + hubId + "/projects";
           return Perform_Get<List<Project>>(connStr);
       }

       public bool CreateNewProject(int hubId, int templateId, string prjName)
       {
           // string jsonToSend = "{'ProjectTemplateId':" + templateId + ",'Name': '" + prjName + "'}";
           //
           // RestRequest request = new RestRequest("v2/hubs/" + hubId + "/projects", Method.POST);
           // request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
           // request.RequestFormat = DataFormat.Json;
           // var response = client.Execute(request);
           // this.ProcessResponseError(response);
           
           
           string jsonToSend = "{'ProjectTemplateId':" + templateId + ",'Name': '" + prjName + "'}";
           string connStr = "v2/hubs/" + hubId + "/projects";
           IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
           return response.IsSuccessful != true;
       }

    }
}
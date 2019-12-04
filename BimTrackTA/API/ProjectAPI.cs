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

    }
}

using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectTemplateApi : APIBase
    {
                
        public List<ProjectTemplate> GetHubProjectTemplates(int hubId)
        {
            string connStr = "v2/hubs/" + hubId + "/projecttemplates";
            return Perform_Get<List<ProjectTemplate>>(connStr);
        }


        public bool CreateHubProjectTemplate(int hubId, int sourceId, string templateName)
        {
            
            string jsonToSend = "{'SourceProjectId': "+ sourceId + ", 'Name':'" + templateName + "'}";
            string connStr = "/v2/hubs/"+ hubId +"/projecttemplates";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful != true;
        }
        
        public bool DeleteHubProjectTemplate(int hubId, int hubProjectTemplateId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projecttemplates/" + hubProjectTemplateId;
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful != true;
        }
        
    }
}
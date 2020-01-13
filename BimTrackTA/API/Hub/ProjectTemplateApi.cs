using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectTemplateApi : ApiBase
    {
                
        public List<ProjectTemplate> GetHubProjectTemplates(int hubId)
        {
            string connStr = "v2/hubs/" + hubId + "/projecttemplates";
            return Perform_Get<List<ProjectTemplate>>(connStr);
        }


        public bool CreateHubProjectTemplate(int hubId, ProjectTemplate template)
        {
            // Required fields for ProjectTemplate object are: 
            //     - Name (string)
            //     - SourceProjectId (int: the id of the source project from which we are creating the template)
            //
            // Since you need a project source, that means that you need to have created a project in that hub first.
            //
            // CTRL+Click on ProjectTemplate for further details about the object's attributes
            string jsonPayload = JsonConvert.SerializeObject(template);
            string connStr = "/v2/hubs/"+ hubId +"/projecttemplates";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteHubProjectTemplate(int hubId, int hubProjectTemplateId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projecttemplates/" + hubProjectTemplateId;
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
        }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectAttributeApi : ApiBase
    {
        public List<ProjectAttribute> GetHubProjectAttributeList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes";
            return Perform_Get<List<ProjectAttribute>>(connStr);
        }
        
        public bool CreateHubProjectAttributeList(int hubId, int projectId, ProjectAttribute prjAttr)
        {
            string json_paylod = JsonConvert.SerializeObject(prjAttr);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes";

            IRestResponse response =  Perform_Create(connStr, json_paylod);
            
            return response.IsSuccessful;
        }
        
        public ProjectAttribute GetHubProjectAttributeDetail(int hubId, int projectId, int attributeId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            return Perform_Get<ProjectAttribute>(connStr);
        }
        
    }
    
}
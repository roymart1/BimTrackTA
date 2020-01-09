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
        
        public bool CreateHubProjectAttribute(int hubId, int projectId, ProjectAttribute prjAttr)
        {
            string jsonPayload = JsonConvert.SerializeObject(prjAttr);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes";

            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }
        
        public ProjectAttribute GetHubProjectAttributeDetail(int hubId, int projectId, int attributeId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            return Perform_Get<ProjectAttribute>(connStr);
        }

        public bool DeleteHubProjectAttribute(int hubId, int projectId, int attributeId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
        }

        public bool UpdateHubProjectAttribute(int hubId, int projectId, int attributeId, ProjectAttribute prjAttr)
        {
            string jsonPayload = JsonConvert.SerializeObject(prjAttr);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + attributeId;
            IRestResponse response = Perform_Update(connStr, jsonPayload);
            return response.IsSuccessful;
        }
    }
    
}
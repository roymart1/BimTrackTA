using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectAttributeValuesApi : ApiBase
    {
        public List<ProjectCustomAttributeValue> GetHubProjectAttributeValueList(int hubId, int projectId, int attrVal)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrVal + "/attributevalues";
            return Perform_Get<List<ProjectCustomAttributeValue>>(connStr);
        }
        
        public bool CreateHubProjectAttributeValue(int hubId, int projectId, int attrId, 
            ProjectCustomAttributeValue prjAttrVal)
        {
            string json_paylod = JsonConvert.SerializeObject(prjAttrVal);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + 
                             attrId + "/attributevalues";

            IRestResponse response =  Perform_Create(connStr, json_paylod);
            
            return response.IsSuccessful;
        }        
        
        public bool DeleteHubProjectAttributeValue(int hubId, int projectId, int attrId, int attrValId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrId + "/attributevalues/" + attrValId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }    
        
    }
}
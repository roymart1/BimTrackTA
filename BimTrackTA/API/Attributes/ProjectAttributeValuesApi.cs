using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectAttributeValuesApi : ApiBase
    {
        public List<PredefinedAttributeValue> GetHubProjectAttributeValueList(int hubId, int projectId, int attrVal)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrVal + "/attributevalues";
            return Perform_Get<List<PredefinedAttributeValue>>(connStr);
        }
        
        public bool CreateHubProjectAttributeValue(int hubId, int projectId, int attrId, 
            PredefinedAttributeValue prjAttrVal)
        {
            string jsonPayload = JsonConvert.SerializeObject(prjAttrVal);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + 
                             attrId + "/attributevalues";

            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }        
        
        public bool DeleteHubProjectAttributeValue(int hubId, int projectId, int attrId, int attrValId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrId + "/attributevalues/" + attrValId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectAttributeValue(int hubId, int projectId, int attrId, int attrValId, PredefinedAttributeValue attribute)
        {
            string jsonPayload = JsonConvert.SerializeObject(attribute);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrId + "/attributevalues/" + attrValId;
            
            IRestResponse response = Perform_Update(connStr, jsonPayload);
            return response.IsSuccessful;
        }
        
    }
}
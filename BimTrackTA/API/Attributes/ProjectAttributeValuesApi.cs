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
        
        public int CreateHubProjectAttributeValue(int hubId, int projectId, int attrId, 
            PredefinedAttributeValue prjAttrVal)
        {
            // Required fields for PredefinedAttributeValue object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + 
                             attrId + "/attributevalues";

            return Perform_Create(connStr, prjAttrVal);
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
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrId + "/attributevalues/" + attrValId;
            
            IRestResponse response = Perform_Update(connStr, attribute);
            return response.IsSuccessful;
        }
        
    }
}
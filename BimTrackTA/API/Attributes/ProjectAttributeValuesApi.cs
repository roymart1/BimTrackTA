using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectAttributeValuesApi : ApiBase
    {
        public List<AttributeValue> GetProjectAttributeValues(int hubId, int projectId, int attId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attId + "/attributevalues";
            return Perform_Get<List<AttributeValue>>(connStr);
        }
        
        public int CreateProjectAttributeValue(int hubId, int projectId, int attrId, 
            AttributeValue prjAttrVal)
        {
            // Required fields for PredefinedAttributeValue object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" + 
                             attrId + "/attributevalues";

            return Perform_Create(connStr, prjAttrVal);
        }        
        
        public bool DeleteProjectAttributeValue(int hubId, int projectId, int attrId, int attrValId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrId + "/attributevalues/" + attrValId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectAttributeValue(int hubId, int projectId, int attrId, int attrValId, AttributeValue attribute)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/attributes/" +
                             attrId + "/attributevalues/" + attrValId;
            
            IRestResponse response = Perform_Update(connStr, attribute);
            return response.IsSuccessful;
        }
        
    }
}
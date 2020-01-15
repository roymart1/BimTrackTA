using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

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
            // Validate that the object is fine
            ValidateOperation(prjAttrVal);
            
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

        private void ValidateOperation(AttributeValue prjAttrVal)
        {
            if (prjAttrVal == null) throw new ArgumentNullException(nameof(prjAttrVal));
            if (prjAttrVal.Name == null)
            {
                throw new CustomObjectAttributeException("a name", "project attribute value");
            }
            if (prjAttrVal.Color == null)
            {
                throw new CustomObjectAttributeException("a color in hex format", "project attribute value");
            }
        }
    }
}
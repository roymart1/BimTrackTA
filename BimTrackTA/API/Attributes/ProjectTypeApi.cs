using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectTypeApi : ApiBase
    {
        public List<BimType> GetProjectTypes(int hubId, int projectId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/types";
            return Perform_Get<List<BimType>>(connStr);
        }

        public int CreateProjectType(int hubId, int projectId, BimType bimType)
        {
            // Validate that the object is fine
            ValidateOperation(bimType);

            // Required fields for BimType object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/types";
            return Perform_Create(connStr, bimType);
        }

        public bool DeleteProjectType(int hubId, int projectId, int typeId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/types/" + typeId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectType(int hubId, int projectId, int typeId, BimType bimType)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/types/" + typeId;
            
            IRestResponse response = Perform_Update(connStr, bimType);
            return response.IsSuccessful;
        }
     
        private void ValidateOperation(BimType type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (type.Name == null)
            {
                throw new CustomObjectAttributeException("a name","project type");
            }
            if (type.Color == null)
            {
                throw new CustomObjectAttributeException("a color in hex format", "project type");
            }
        }
    }
}
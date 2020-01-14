using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectTypeApi : ApiBase
    {
        public List<BimType> GetHubProjectTypeList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/types";
            return Perform_Get<List<BimType>>(connStr);
        }

        public bool CreateHubProjectType(int hubId, int projectId, BimType bimType)
        {
            // Required fields for BimType object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/types";
            IRestResponse response =  Perform_Create(connStr, bimType);
            
            return response.IsSuccessful;
        }

        public bool DeleteHubProjectType(int hubId, int projectId, int typeId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/types/" + typeId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectType(int hubId, int projectId, int typeId, BimType bimType)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/types/" + typeId;
            
            IRestResponse response = Perform_Update(connStr, bimType);
            return response.IsSuccessful;
        }
        
    }
}
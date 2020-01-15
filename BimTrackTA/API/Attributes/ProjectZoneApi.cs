using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectZoneApi : ApiBase
    {
        public List<Zone> GetProjectZones(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones";
            return Perform_Get<List<Zone>>(connStr);
        }

        public int CreateProjectZone(int hubId, int projectId, Zone zone)
        {
            // Required fields for Zone object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones";
            return Perform_Create(connStr, zone);
        }

        public bool DeleteProjectZone(int hubId, int projectId, int zoneId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones/" + zoneId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectZone(int hubId, int projectId, int zoneId, Zone zone)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones/" + zoneId;
            
            IRestResponse response = Perform_Update(connStr, zone);
            return response.IsSuccessful;
        }
        
    }
}
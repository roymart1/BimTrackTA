using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectZoneApi : ApiBase
    {
        public List<Zone> GetHubProjectZoneList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones";
            return Perform_Get<List<Zone>>(connStr);
        }

        public bool CreateHubProjectZone(int hubId, int projectId, Zone zone)
        {
            string jsonPayload = JsonConvert.SerializeObject(zone);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }

        public bool DeleteHubProjectZone(int hubId, int projectId, int zoneId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones/" + zoneId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectZone(int hubId, int projectId, int zoneId, Zone zone)
        {
            string jsonPayload = JsonConvert.SerializeObject(zone);
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/zones/" + zoneId;
            
            IRestResponse response = Perform_Update(connStr, jsonPayload);
            return response.IsSuccessful;
        }
        
    }
}
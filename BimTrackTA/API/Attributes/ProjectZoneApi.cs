using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{

    public class ProjectZoneApi : ApiBase
    {
        public List<Zone> GetProjectZones(int hubId, int projectId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/zones";
            return Perform_Get<List<Zone>>(connStr);
        }

        public int CreateProjectZone(int hubId, int projectId, Zone zone)
        {
            // Validate that the object is fine
            ValidateOperation(zone);
            
            // Required fields for Zone object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/zones";
            return Perform_Create(connStr, zone);
        }

        public bool DeleteProjectZone(int hubId, int projectId, int zoneId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/zones/" + zoneId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateProjectZone(int hubId, int projectId, int zoneId, Zone zone)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/zones/" + zoneId;
            
            IRestResponse response = Perform_Update(connStr, zone);
            return response.IsSuccessful;
        }
        
        private void ValidateOperation(Zone zone)
        {
            if (zone == null) throw new ArgumentNullException(nameof(zone));
            if (zone.Name == null)
            {
                throw new CustomObjectAttributeException("a name","project zone");
            }
            if (zone.Color == null)
            {
                throw new CustomObjectAttributeException("a color in hex format", "project zone");
            }
        }
    }
}
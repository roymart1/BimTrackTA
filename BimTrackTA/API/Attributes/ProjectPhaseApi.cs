using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{

    public class ProjectPhaseApi : ApiBase
    {
        public List<Phase> GetHubProjectPhaseList(int hubId, int projectId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/phases";
            return Perform_Get<List<Phase>>(connStr);
        }

        public int CreateHubProjectPhase(int hubId, int projectId, Phase phase)
        {
            // Required fields for Phase object are: 
            //     - Name (string)
            //     - Color (hex format)
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/phases";
            return Perform_Create(connStr, phase);
        }

        public bool DeleteHubProjectPhase(int hubId, int projectId, int phaseId)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/phases/" + phaseId;
            
            IRestResponse response = Perform_Delete(connStr);
            return response.IsSuccessful;
            
        }

        public bool UpdateHubProjectPhase(int hubId, int projectId, int phaseId, Phase phase)
        {
            string connStr = "/v2/hubs/" + hubId + "/projects/" + projectId + "/phases/" + phaseId;
            
            IRestResponse response = Perform_Update(connStr, phase);
            return response.IsSuccessful;
        }
        
    }
}